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
using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;
using Maladin.Services.Extensions;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
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
                options.UpdateAuthorize = GetUpdateAdminAllow;
                options.CreateAuthorize = GetCreateAdminAllow;
                options.DeleteAuthorize = GetDeleteAdminAllow;
            });

            builder.Services.AddEntityAuthorizeOptions<BookController, Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.BeforeReadAuthorize = GetBeforeReadAdminAllow;
                options.CreateAuthorize = GetCreateAdminAllow;
                options.UpdateAuthorize = GetUpdateAdminAllow;
                options.DeleteAuthorize = GetDeleteAdminAllow;
            });

            builder.Services.AddEntityAuthorizeOptions<DeliveryController, Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.CreateAuthorize = GetCreateAdminAllow;
                options.UpdateAuthorize = GetUpdateAdminAllow;
                options.DeleteAuthorize = GetDeleteAdminAllow;
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCartController, GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.ReadAuthorize = (context, read) => ValueTask.FromResult(IsAdmin(context.User) || context.User.FindFirstValue(JwtRegisteredClaimNames.Sub) is string sub && read.UserId == int.Parse(sub));
                options.CreateAuthorize = (context, create) => ValueTask.FromResult(IsAdmin(context.User) || context.User.FindFirstValue(JwtRegisteredClaimNames.Sub) is string sub && create.UserId == int.Parse(sub));
                options.UpdateAuthorize = (context, _, update) =>
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCategoryController, GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>();
            builder.Services.AddEntityAuthorizeOptions<GoodsController, Goods, GoodsRead, GoodsCreate, GoodsUpdate>();
            builder.Services.AddEntityAuthorizeOptions<GoodsOrderController, GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>();
            builder.Services.AddEntityAuthorizeOptions<GoodsReviewController, GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>();
            builder.Services.AddEntityAuthorizeOptions<MembershipController, Membership, MembershipRead, MembershipCreate, MembershipUpdate>();
            builder.Services.AddEntityAuthorizeOptions<OAuthIdController, OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>();
            builder.Services.AddEntityAuthorizeOptions<OAuthProviderController, OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>();
            builder.Services.AddEntityAuthorizeOptions<OrderSetController, OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>();
            builder.Services.AddEntityAuthorizeOptions<PaymentController, Payment, PaymentRead, PaymentCreate, PaymentUpdate>();
            builder.Services.AddEntityAuthorizeOptions<PointController, Point, PointRead, PointCreate, PointUpdate>();
            builder.Services.AddEntityAuthorizeOptions<PublisherController, Publisher, PublisherRead, PublisherCreate, PublisherUpdate>();
            builder.Services.AddEntityAuthorizeOptions<RoleController, Role, RoleRead, RoleCreate, RoleUpdate>();
            builder.Services.AddEntityAuthorizeOptions<TranslatorController, Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>();
            builder.Services.AddEntityAuthorizeOptions<UserAddressController, UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>();
            builder.Services.AddEntityAuthorizeOptions<UserController, User, UserRead, UserCreate, UserUpdate>();
        }

        private static ValueTask<bool> GetBeforeReadAdminAllow(HttpContext context) => ValueTask.FromResult(IsAdmin(context.User));

        private static ValueTask<bool> GetCreateAdminAllow<TCreate>(HttpContext context, TCreate create) => ValueTask.FromResult(IsAdmin(context.User));

        private static ValueTask<bool> GetUpdateAdminAllow<TUpdate>(HttpContext context, int id, TUpdate update) => ValueTask.FromResult(IsAdmin(context.User));

        private static ValueTask<bool> GetDeleteAdminAllow(HttpContext context, int id) => ValueTask.FromResult(IsAdmin(context.User));

        private static bool IsAdmin(ClaimsPrincipal user)
        {
            return user.Identity is { AuthenticationType: JwtBearerDefaults.AuthenticationScheme, IsAuthenticated: true } && user.IsInRole(AuthorizeRole.Admin);
        }
    }
}