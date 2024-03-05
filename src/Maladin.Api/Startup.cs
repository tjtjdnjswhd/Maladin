using AspNet.Security.OAuth.KakaoTalk;
using AspNet.Security.OAuth.Naver;

using Maladin.Api.Constants;
using Maladin.Api.Controllers.Entity;
using Maladin.Api.Extensions;
using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;
using Maladin.Services.Extensions;
using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;

namespace Maladin.Api
{
    public static class Startup
    {
        public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder, string jwtSectionName, Func<string, SecurityKey> keyGenerator)
        {
            var jwtOptionsSection = builder.Configuration.GetRequiredSection(jwtSectionName);
            JwtOptions jwtOptions = jwtOptionsSection.Get<JwtOptions>() ?? throw new NullReferenceException();
            builder.Services.Configure<JwtOptions>(jwtOptionsSection);
            builder.Services.AddJwtService(jwtOptions.SecurityAlgorithm, keyGenerator);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = keyGenerator(jwtOptions.SecureKey),
                };

                options.Events = new()
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException)
                        {
                            context.Response.Headers.Append("Access-Token-Expired", StringValues.Empty);
                        }
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies.TryGetValue(jwtOptions.AccessTokenName, out string? accessToken) ? accessToken : null;
                        return Task.CompletedTask;
                    }
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProviderName:Google:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProviderName:Google:ClientSecret") ?? throw new NullReferenceException();
                options.AuthorizationEndpoint += "?prompt=consent";
            })
            .AddKakaoTalk(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProviderName:Kakaotalk:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProviderName:Kakaotalk.ClientSecret") ?? throw new NullReferenceException();
                options.AuthorizationEndpoint += "?prompt=login";
            })
            .AddNaver(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProviderName:Naver:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProviderName:Naver:ClientSecret") ?? throw new NullReferenceException();
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigureAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorizationBuilder()
                .AddPolicy(AuthorizePolicy.OAUTH, pb =>
                {
                    pb.AddAuthenticationSchemes(GoogleDefaults.AuthenticationScheme, KakaoTalkAuthenticationDefaults.AuthenticationScheme, NaverAuthenticationDefaults.AuthenticationScheme);
                    pb.RequireAuthenticatedUser().RequireClaim(ClaimTypes.NameIdentifier);
                })
                .AddPolicy(AuthorizePolicy.USER, pb =>
                {
                    pb.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    pb.RequireAuthenticatedUser().RequireRole(AuthorizeRole.User);
                })
                .AddPolicy(AuthorizePolicy.ADMIN, pb =>
                {
                    pb.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    pb.RequireAuthenticatedUser().RequireRole(AuthorizeRole.Admin);
                });

            return builder;
        }

        public static WebApplicationBuilder ConfigureEntityControllerAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddEntityAuthorizeOptions<AuthorController, Author, AuthorRead, AuthorCreate, AuthorUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<BookController, Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAdmin());
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<DeliveryController, Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCartController, GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCategoryController, GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsController, Goods, GoodsRead, GoodsCreate, GoodsUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsOrderController, GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(options =>
            {
                static async Task<bool> IsUserHasGoodsOrder(HttpContext httpContext, int entityId)
                {
                    using var scope = httpContext.RequestServices.CreateScope();
                    IJwtService jwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();
                    if (!jwtService.TryGetUserId(httpContext.User.Claims, out int userId))
                    {
                        return false;
                    }

                    MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
                    return await dbContext.GoodsOrders.AnyAsync(p => p.Id == entityId && p.OrderSet.UserId == userId);
                }

                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserHasGoodsOrder(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, update) => context.User.IsAdmin() || await IsUserHasGoodsOrder(context, entityId);
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsReviewController, GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(options =>
            {
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
            });


            builder.Services.AddEntityAuthorizeOptions<MembershipController, Membership, MembershipRead, MembershipCreate, MembershipUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<OAuthIdController, OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<OAuthProviderController, OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<OrderSetController, OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<OrderSet>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<OrderSet>(context, entityId);
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<PaymentController, Payment, PaymentRead, PaymentCreate, PaymentUpdate>(options =>
            {
                static async Task<bool> IsUserHasPayment(HttpContext httpContext, int entityId)
                {
                    using var scope = httpContext.RequestServices.CreateScope();
                    IJwtService jwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();
                    if (!jwtService.TryGetUserId(httpContext.User.Claims, out int userId))
                    {
                        return false;
                    }

                    MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
                    return await dbContext.Payments.AnyAsync(p => p.Id == entityId && p.Order.UserId == userId);
                }

                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserHasPayment(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, update) => context.User.IsAdmin() || await IsUserHasPayment(context, entityId);
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<PointController, Point, PointRead, PointCreate, PointUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<Point>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<Point>(context, entityId);
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<PublisherController, Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<RoleController, Role, RoleRead, RoleCreate, RoleUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAdmin());
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<TranslatorController, Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<UserAddressController, UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<UserController, User, UserRead, UserCreate, UserUpdate>(options =>
            {
                options.ReadAuthorize = (context, read) => ValueTask.FromResult(context.User.IsAdmin() || context.TryGetUserId(out int userId) && read.Id == userId);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, entityId, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });

            return builder;
        }

        private static async Task<bool> IsUserIdMatch<T>(HttpContext context, int entityId)
            where T : EntityBase, IUserRelationEntity
        {
            if (!context.TryGetUserId(out int userId))
            {
                return false;
            }

            using var scope = context.RequestServices.CreateScope();
            MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
            return await dbContext.IsUserHaveEntityAsync<T>(entityId, userId, context.RequestAborted);
        }
    }
}