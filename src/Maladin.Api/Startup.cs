using AspNet.Security.OAuth.KakaoTalk;
using AspNet.Security.OAuth.Naver;

using LinqExpressionParser.AspNetCore.Extensions;

using Maladin.Api.Constants;
using Maladin.Api.Extensions;
using Maladin.Api.ModelBinders;
using Maladin.Api.Models.Dtos;
using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;
using Maladin.EFCore.Models.Enums;
using Maladin.Services.Extensions;

using MappedExpressionProvider;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

using System.Linq.Expressions;

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
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientSecret") ?? throw new NullReferenceException();
            })
            .AddKakaoTalk(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Kakaotalk:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Kakaotalk:ClientSecret") ?? throw new NullReferenceException();
                options.AuthorizationEndpoint += "?prompt=login";
            })
            .AddNaver(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Naver:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Naver:ClientSecret") ?? throw new NullReferenceException();
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

        public static WebApplicationBuilder ConfigureEntityOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MvcOptions>(options =>
            {
                Dictionary<EGoodsKind, DtoTypes> goodsTypesByKind = new()
                {
                    { EGoodsKind.BookDisplay, new DtoTypes(typeof(BookDisplayRead), typeof(BookDisplayCreate), typeof(BookDisplayUpdate)) },
                    { EGoodsKind.Pencil, new DtoTypes(typeof(PencilRead), typeof(PencilCreate), typeof(PencilUpdate)) }
                };
                options.ModelBinderProviders.Insert(0, new GoodsModelBinderProvider(goodsTypesByKind));
            });

            builder.Services.AddExpressionParse();
            builder.Services.AddScoped<IEntityConfigurationService, EntityConfigurationService>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureEntityActionFilter(this WebApplicationBuilder builder)
        {
            builder.Services.AddEntityActionFilterOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAdmin(context));
                options.AfterRead = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(context.User.IsAuthenticated() ? null : new UnauthorizedResult());
                options.AfterRead = async (context, read) => await AuthorizeAdminOrUserIdAsync<GoodsCart>(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<GoodsCart>(context, entityId);
                options.BeforeDelete = async (context, entityId) => await AuthorizeAdminOrUserIdAsync<GoodsCart>(context, entityId);
            });

            builder.Services.AddEntityActionFilterOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(options =>
            {
                static async Task<IActionResult?> AuthorizeAdminOrHaveGoodsOrderAsync(HttpContext httpContext, int entityId)
                {
                    if (!httpContext.TryGetUserId(out int userId))
                    {
                        return new UnauthorizedResult();
                    }

                    using var scope = httpContext.RequestServices.CreateScope();
                    MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
                    return await dbContext.GoodsOrders.AnyAsync(g => g.Id == entityId && g.OrderSet.UserId == userId) ? null : new ForbidResult();
                }

                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeAdminOrHaveGoodsOrderAsync(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, update) => await AuthorizeAdminOrHaveGoodsOrderAsync(context, entityId);
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<GoodsCart>(context, entityId);
                options.BeforeDelete = async (context, entityId) => await AuthorizeAdminOrUserIdAsync<GoodsCart>(context, entityId);
            });

            builder.Services.AddEntityActionFilterOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeAdminOrUserIdAsync<OAuthId>(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<OAuthId>(context, entityId);
                options.BeforeDelete = async (context, entityId) => await AuthorizeAdminOrUserIdAsync<OAuthId>(context, entityId);
            });

            builder.Services.AddEntityActionFilterOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeAdminOrUserIdAsync<OrderSet>(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<OrderSet>(context, entityId);
                options.BeforeDelete = (context, entityId) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(options =>
            {
                static async Task<IActionResult?> AuthorizeIsAdminOrHavePaymentAsync(HttpContext httpContext, int entityId)
                {
                    if (!httpContext.TryGetUserId(out int userId))
                    {
                        return new UnauthorizedResult();
                    }

                    using var scope = httpContext.RequestServices.CreateScope();
                    MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
                    return await dbContext.Payments.AnyAsync(p => p.Id == entityId && p.Order.UserId == userId) ? null : new ForbidResult();
                }

                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeIsAdminOrHavePaymentAsync(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, update) => await AuthorizeIsAdminOrHavePaymentAsync(context, entityId);
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Point, PointRead, PointCreate, PointUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeAdminOrUserIdAsync<Point>(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<Point>(context, entityId);
                options.BeforeDelete = (context, entityId) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Role, RoleRead, RoleCreate, RoleUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAdmin(context));
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, _) => Task.FromResult<IActionResult?>(null);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, _, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, _) => Task.FromResult(AuthorizeAdmin(context));
            });

            builder.Services.AddEntityActionFilterOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult(AuthorizeAuthenticated(context));
                options.AfterRead = async (context, read) => await AuthorizeAdminOrUserIdAsync<UserAddress>(context, read.Id);
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAuthenticated(context));
                options.BeforeUpdate = async (context, entityId, _) => await AuthorizeAdminOrUserIdAsync<UserAddress>(context, entityId);
                options.BeforeDelete = async (context, entityId) => await AuthorizeAdminOrUserIdAsync<UserAddress>(context, entityId);
            });

            builder.Services.AddEntityActionFilterOptions<User, UserRead, UserCreate, UserUpdate>(options =>
            {
                options.BeforeRead = context => Task.FromResult<IActionResult?>(null);
                options.AfterRead = (context, read) => Task.FromResult<IActionResult?>(context.User.IsAdmin() || context.TryGetUserId(out int userId) && read.Id == userId ? null : new UnauthorizedResult());
                options.BeforeCreate = (context, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeUpdate = (context, entityId, _) => Task.FromResult(AuthorizeAdmin(context));
                options.BeforeDelete = (context, entityId) => Task.FromResult(AuthorizeAdmin(context));
            });

            return builder;

            static IActionResult? AuthorizeAdmin(HttpContext httpContext) => httpContext.User.IsAdmin() ? null : httpContext.User.IsAuthenticated() ? new ForbidResult() : new UnauthorizedResult();

            static IActionResult? AuthorizeAuthenticated(HttpContext httpContext) => httpContext.User.IsAuthenticated() ? null : new UnauthorizedResult();

            static async Task<IActionResult?> AuthorizeAdminOrUserIdAsync<T>(HttpContext httpContext, int entityId)
               where T : EntityBase, IUserRelationEntity
            {
                if (httpContext.User.IsAdmin())
                {
                    return null;
                }

                if (!httpContext.TryGetUserId(out int userId))
                {
                    return new UnauthorizedResult();
                }

                using var scope = httpContext.RequestServices.CreateScope();
                MaladinDbContext dbContext = scope.ServiceProvider.GetRequiredService<MaladinDbContext>();
                return (await dbContext.IsUserRelationAsync<T>(entityId, userId, httpContext.RequestAborted)) ? null : new ForbidResult();
            }
        }

        public static WebApplicationBuilder ConfigureCrudOptions(this WebApplicationBuilder builder)
        {
            MappedExpressionProvider.MappedExpressionProvider expressionProvider = BuildReferenceExpression(1, false);

            builder.Services.AddEntityQueryOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Author, AuthorRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Author, AuthorRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<AuthorRead>();
                options.CreateFunc = CreateAuthor;
                options.UpdateFunc = UpdateAuthor;
            });

            builder.Services.AddEntityQueryOptions<Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Book, BookRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Book, BookRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<BookRead>();
                options.CreateFunc = CreateBook;
                options.UpdateFunc = UpdateBook;
            });

            builder.Services.AddEntityQueryOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<BookDisplay, BookDisplayRead>(true);
                options.ProjectionExpression = expressionProvider.Get<BookDisplay, BookDisplayRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<BookDisplayRead>();
                options.CreateFunc = CreateBookDisplay;
                options.UpdateFunc = UpdateBookDisplay;
            });

            builder.Services.AddEntityQueryOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Delivery, DeliveryRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Delivery, DeliveryRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<DeliveryRead>();
                options.CreateFunc = CreateDelivery;
                options.UpdateFunc = UpdateDelivery;
            });

            builder.Services.AddEntityQueryOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Goods, GoodsRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Goods, GoodsRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<GoodsRead>();
                options.CreateFunc = CreateGoods;
                options.UpdateFunc = UpdateGoods;
            });

            builder.Services.AddEntityQueryOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<GoodsCart, GoodsCartRead>(true);
                options.ProjectionExpression = expressionProvider.Get<GoodsCart, GoodsCartRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<GoodsCartRead>();
                options.CreateFunc = CreateGoodsCart;
                options.UpdateFunc = UpdateGoodsCart;
            });

            builder.Services.AddEntityQueryOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<GoodsCategory, GoodsCategoryRead>(true);
                options.ProjectionExpression = expressionProvider.Get<GoodsCategory, GoodsCategoryRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<GoodsCategoryRead>();
                options.CreateFunc = CreateGoodsCategory;
                options.UpdateFunc = UpdateGoodsCategory;
            });

            builder.Services.AddEntityQueryOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<GoodsOrder, GoodsOrderRead>(true);
                options.ProjectionExpression = expressionProvider.Get<GoodsOrder, GoodsOrderRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<GoodsOrderRead>();
                options.CreateFunc = CreateGoodsOrder;
                options.UpdateFunc = UpdateGoodsOrder;
            });

            builder.Services.AddEntityQueryOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<GoodsReview, GoodsReviewRead>(true);
                options.ProjectionExpression = expressionProvider.Get<GoodsReview, GoodsReviewRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<GoodsReviewRead>();
                options.CreateFunc = CreateGoodsReview;
                options.UpdateFunc = UpdateGoodsReview;
            });

            builder.Services.AddEntityQueryOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Membership, MembershipRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Membership, MembershipRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<MembershipRead>();
                options.CreateFunc = CreateMembership;
                options.UpdateFunc = UpdateMembership;
            });

            builder.Services.AddEntityQueryOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<OAuthId, OAuthIdRead>(true);
                options.ProjectionExpression = expressionProvider.Get<OAuthId, OAuthIdRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<OAuthIdRead>();
                options.CreateFunc = CreateOAuthId;
                options.UpdateFunc = UpdateOAuthId;
            });

            builder.Services.AddEntityQueryOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<OAuthProvider, OAuthProviderRead>(true);
                options.ProjectionExpression = expressionProvider.Get<OAuthProvider, OAuthProviderRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<OAuthProviderRead>();
                options.CreateFunc = CreateOAuthProvider;
                options.UpdateFunc = UpdateOAuthProvider;
            });

            builder.Services.AddEntityQueryOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<OrderSet, OrderSetRead>(true);
                options.ProjectionExpression = expressionProvider.Get<OrderSet, OrderSetRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<OrderSetRead>();
                options.CreateFunc = CreateOrderSet;
                options.UpdateFunc = UpdateOrderSet;
            });

            builder.Services.AddEntityQueryOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Payment, PaymentRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Payment, PaymentRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<PaymentRead>();
                options.CreateFunc = CreatePayment;
                options.UpdateFunc = UpdatePayment;
            });

            builder.Services.AddEntityQueryOptions<Point, PointRead, PointCreate, PointUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Point, PointRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Point, PointRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<PointRead>();
                options.CreateFunc = CreatePoint;
                options.UpdateFunc = UpdatePoint;
            });

            builder.Services.AddEntityQueryOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Publisher, PublisherRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Publisher, PublisherRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<PublisherRead>();
                options.CreateFunc = CreatePublisher;
                options.UpdateFunc = UpdatePublisher;
            });

            builder.Services.AddEntityQueryOptions<Role, RoleRead, RoleCreate, RoleUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Role, RoleRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Role, RoleRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<RoleRead>();
                options.CreateFunc = CreateRole;
                options.UpdateFunc = UpdateRole;
            });

            builder.Services.AddEntityQueryOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<Translator, TranslatorRead>(true);
                options.ProjectionExpression = expressionProvider.Get<Translator, TranslatorRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<TranslatorRead>();
                options.CreateFunc = CreateTranslator;
                options.UpdateFunc = UpdateTranslator;
            });

            builder.Services.AddEntityQueryOptions<User, UserRead, UserCreate, UserUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<User, UserRead>(true);
                options.ProjectionExpression = expressionProvider.Get<User, UserRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<UserRead>();
                options.CreateFunc = CreateUser;
                options.UpdateFunc = UpdateUser;
            });

            builder.Services.AddEntityQueryOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(options =>
            {
                options.ReferenceExpression = expressionProvider.Get<UserAddress, UserAddressRead>(true);
                options.ProjectionExpression = expressionProvider.Get<UserAddress, UserAddressRead>(false);
                options.ReferenceToProjectionExpression = expressionProvider.Get<UserAddressRead>();
                options.CreateFunc = CreateUserAddress;
                options.UpdateFunc = UpdateUserAddress;
            });

            return builder;

            #region CreateFunc
            static Author CreateAuthor(AuthorCreate dto) => new(dto.Name, dto.Introduce);

            static BookDisplay CreateBookDisplay(BookDisplayCreate dto) => new(dto.Name, dto.Overview, dto.Price, dto.PaperSize, dto.PageCount, dto.CoverUrl, dto.PublishedAt, dto.BookId, dto.AuthorId, dto.TranslatorId, dto.PublisherId, dto.CategoryId);

            static Book CreateBook(BookCreate dto) => new(dto.Stock, dto.Isbn, dto.Sales);

            static Delivery CreateDelivery(DeliveryCreate dto) => new(dto.Name);

            static Goods CreateGoods(GoodsCreate dto) => dto switch
            {
                BookDisplayCreate bookDisplay => new BookDisplay(bookDisplay.Name, bookDisplay.Overview, bookDisplay.Price, bookDisplay.PaperSize, bookDisplay.PageCount, bookDisplay.CoverUrl, bookDisplay.PublishedAt, bookDisplay.BookId, bookDisplay.AuthorId, bookDisplay.TranslatorId, bookDisplay.PublisherId, bookDisplay.CategoryId),
                _ => throw new ArgumentException("Invalid goods type")
            };

            static GoodsCart CreateGoodsCart(GoodsCartCreate dto) => new(dto.Count, dto.UserId, dto.GoodsId);

            static GoodsCategory CreateGoodsCategory(GoodsCategoryCreate dto) => dto.ParentId is null ? new GoodsCategory(dto.Name) : new GoodsCategory(dto.Name, dto.ParentId.Value);

            static GoodsOrder CreateGoodsOrder(GoodsOrderCreate dto) => new(dto.Price, dto.OrderQty, dto.OrderSetId, dto.GoodsId);

            static GoodsReview CreateGoodsReview(GoodsReviewCreate dto) => new(dto.Content, dto.Rating, dto.UserId, dto.GoodsId);

            static Membership CreateMembership(MembershipCreate dto) => new(dto.Level, dto.PointPercentage);

            static OAuthId CreateOAuthId(OAuthIdCreate dto) => new(dto.NameIdentifier, dto.ProviderId, dto.UserId);

            static OAuthProvider CreateOAuthProvider(OAuthProviderCreate dto) => new(dto.Name);

            static OrderSet CreateOrderSet(OrderSetCreate dto) => new(dto.UsedPoints, dto.Address, dto.PostCode, dto.ReceiverName, dto.Message, dto.PhoneNumber, dto.UserId);

            static Payment CreatePayment(PaymentCreate dto) => new(Enum.Parse<EPaymentStatus>(dto.Status));

            static Point CreatePoint(PointCreate dto) => new(dto.Amount, dto.UserId);

            static Publisher CreatePublisher(PublisherCreate dto) => new(dto.Name, dto.Introduce);

            static Role CreateRole(RoleCreate dto) => new(dto.Name, dto.Priority);

            static Translator CreateTranslator(TranslatorCreate dto) => new(dto.Name, dto.Introduce);

            static UserAddress CreateUserAddress(UserAddressCreate dto) => new(dto.Address, dto.PostCode, dto.IsDefault, dto.UserId);

            static User CreateUser(UserCreate dto) => throw new NotImplementedException();
            #endregion

            #region UpdateFunc
            static void UpdateAuthor(Author entity, AuthorUpdate dto)
            {
                entity.Name = dto.Name;
                entity.Introduce = dto.Introduce;
            }

            static void UpdateBookDisplay(BookDisplay entity, BookDisplayUpdate dto)
            {
                entity.Name = dto.Name;
                entity.Overview = dto.Overview;
                entity.Price = dto.Price;
                entity.PaperSize = dto.PaperSize;
                entity.PageCount = dto.PageCount;
                entity.CoverUrl = dto.CoverUrl;
                entity.PublishedAt = dto.PublishedAt;
                entity.BookId = dto.BookId;
                entity.AuthorId = dto.AuthorId;
                entity.TranslatorId = dto.TranslatorId;
                entity.PublisherId = dto.PublisherId;
                entity.CategoryId = dto.CategoryId;
            }

            static void UpdateBook(Book entity, BookUpdate dto)
            {
                entity.Stock = dto.Stock;
                entity.Isbn = dto.Isbn;
                entity.Sales = dto.Sales;
            }

            static void UpdateDelivery(Delivery entity, DeliveryUpdate dto)
            {
                entity.Name = dto.Name;
            }

            static void UpdateGoods(Goods entity, GoodsUpdate dto)
            {
                switch (entity)
                {
                    case BookDisplay bookDisplay:
                        {
                            if (dto is not BookDisplayUpdate update)
                            {
                                throw new ArgumentException("dto is not type of BookDisplay");
                            }

                            bookDisplay.Name = update.Name;
                            bookDisplay.Overview = update.Overview;
                            bookDisplay.Price = update.Price;
                            bookDisplay.PaperSize = update.PaperSize;
                            bookDisplay.PageCount = update.PageCount;
                            bookDisplay.CoverUrl = update.CoverUrl;
                            bookDisplay.PublishedAt = update.PublishedAt;
                            bookDisplay.BookId = update.BookId;
                            bookDisplay.AuthorId = update.AuthorId;
                            bookDisplay.TranslatorId = update.TranslatorId;
                            bookDisplay.PublisherId = update.PublisherId;
                            bookDisplay.CategoryId = update.CategoryId;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("Invalid goods type");
                        }
                }
            }

            static void UpdateGoodsCart(GoodsCart entity, GoodsCartUpdate dto)
            {
                entity.Count = dto.Count;
            }

            static void UpdateGoodsCategory(GoodsCategory entity, GoodsCategoryUpdate dto)
            {
                entity.Name = dto.Name;
                entity.ParentId = dto.ParentId;
            }

            static void UpdateGoodsOrder(GoodsOrder entity, GoodsOrderUpdate dto)
            {
                entity.CancelQty = dto.CancelQty;
            }

            static void UpdateGoodsReview(GoodsReview entity, GoodsReviewUpdate dto)
            {
                entity.Content = dto.Content;
                entity.Rating = dto.Rating;
            }

            static void UpdateMembership(Membership entity, MembershipUpdate dto)
            {
                entity.Level = dto.Level;
                entity.PointPercentage = dto.PointPercentage;
            }

            static void UpdateOAuthId(OAuthId entity, OAuthIdUpdate dto)
            {
            }

            static void UpdateOAuthProvider(OAuthProvider entity, OAuthProviderUpdate dto)
            {
                entity.Name = dto.Name;
            }

            static void UpdateOrderSet(OrderSet entity, OrderSetUpdate dto)
            {
                entity.UsedPoints = dto.UsedPoints;
                entity.State = Enum.Parse<EOrderSetStatus>(dto.State, true);
                entity.Address = dto.Address;
                entity.PostCode = dto.PostCode;
                entity.ReceiverName = dto.ReceiverName;
                entity.DeliveryId = dto.DeliveryId;
                entity.Message = dto.Message;
                entity.PhoneNumber = dto.PhoneNumber;
                entity.UserId = dto.UserId;
                entity.PaymentId = dto.PaymentId;
                entity.InvoiceNumber = dto.InvoiceNumber;
            }

            static void UpdatePayment(Payment entity, PaymentUpdate dto)
            {
                entity.Status = Enum.Parse<EPaymentStatus>(dto.Status);
                entity.BalanceAmount = dto.BalanceAmount;
                entity.PaidAmount = dto.PaidAmount;
                entity.ImpUid = dto.ImpUid;
            }

            static void UpdatePoint(Point entity, PointUpdate dto)
            {
                entity.Amount = dto.Amount;
            }

            static void UpdatePublisher(Publisher entity, PublisherUpdate dto)
            {
                entity.Name = dto.Name;
                entity.Introduce = dto.Introduce;
            }

            static void UpdateRole(Role entity, RoleUpdate dto)
            {
                entity.Name = dto.Name;
                entity.Priority = dto.Priority;
            }

            static void UpdateTranslator(Translator entity, TranslatorUpdate dto)
            {
                entity.Name = dto.Name;
                entity.Introduce = dto.Introduce;
            }

            static void UpdateUserAddress(UserAddress entity, UserAddressUpdate dto)
            {
                entity.Address = dto.Address;
                entity.PostCode = dto.PostCode;
                entity.IsDefault = dto.IsDefault;
            }

            static void UpdateUser(User entity, UserUpdate dto)
            {
                entity.IsExpired = dto.IsExpired;
                entity.IsLocked = dto.IsLocked;
                entity.MembershipId = dto.MembershipId;
            }
            #endregion
        }

        private static MappedExpressionProvider.MappedExpressionProvider BuildReferenceExpression(int maxDepth, bool referenceRecursion)
        {
            MappedExpressionProviderBuilder referenceExpressionProviderBuilder = new();
            Expression<Func<Author, AuthorRead>> authorToReadExpression = a => new AuthorRead() { Id = a.Id, Introduce = a.Introduce, Name = a.Name };
            Expression<Func<BookDisplay, BookDisplayRead>> bookDisplayToReadExpression = b => new BookDisplayRead()
            {
                Id = b.Id,
                Name = b.Name,
                PageCount = b.PageCount,
                PaperSize = b.PaperSize,
                PublishedAt = b.PublishedAt,
                Price = b.Price,
                Overview = b.Overview,
                CoverUrl = b.CoverUrl,
                AuthorId = b.AuthorId,
                BookId = b.BookId,
                CategoryId = b.CategoryId,
                PublisherId = b.PublisherId,
                TranslatorId = b.TranslatorId,
            };
            Expression<Func<Book, BookRead>> bookToReadExpression = b => new BookRead() { Id = b.Id, Isbn = b.Isbn, Sales = b.Sales, Stock = b.Stock };
            Expression<Func<Delivery, DeliveryRead>> deliveryToReadExpression = d => new DeliveryRead() { Id = d.Id, Name = d.Name };
            Expression<Func<Goods, GoodsRead>> goodsToReadExpression = g => new GoodsRead() { Id = g.Id, Name = g.Name, Overview = g.Overview, Price = g.Price, CategoryId = g.CategoryId };
            Expression<Func<GoodsCart, GoodsCartRead>> goodsCartToReadExpression = g => new GoodsCartRead() { Id = g.Id, Count = g.Count, GoodsId = g.GoodsId, UserId = g.UserId };
            Expression<Func<GoodsCategory, GoodsCategoryRead>> goodsCategoryToReadExpression = g => new GoodsCategoryRead() { Id = g.Id, Name = g.Name, ParentId = g.ParentId };
            Expression<Func<GoodsOrder, GoodsOrderRead>> goodsOrderToReadExpression = g => new GoodsOrderRead() { Id = g.Id, CancelQty = g.CancelQty, GoodsId = g.GoodsId, OrderQty = g.OrderQty, OrderSetId = g.OrderSetId };
            Expression<Func<GoodsReview, GoodsReviewRead>> goodsReviewToReadExpression = g => new GoodsReviewRead() { Id = g.Id, CreatedAt = g.CreatedAt, GoodsId = g.GoodsId, Content = g.Content, Rating = g.Rating, UserId = g.UserId };
            Expression<Func<Membership, MembershipRead>> membershipToReadExpression = m => new MembershipRead() { Id = m.Id, Level = m.Level, PointPercentage = m.PointPercentage };
            Expression<Func<OAuthId, OAuthIdRead>> oAuthIdToReadExpression = o => new OAuthIdRead() { Id = o.Id, NameIdentifier = o.NameIdentifier, ProviderId = o.ProviderId, UserId = o.UserId };
            Expression<Func<OAuthProvider, OAuthProviderRead>> oAuthProviderToReadExpression = o => new OAuthProviderRead() { Id = o.Id, Name = o.Name };
            Expression<Func<OrderSet, OrderSetRead>> orderSetToReadExpression = o => new OrderSetRead()
            {
                Id = o.Id,
                Uid = o.Uid,
                Address = o.Address,
                Message = o.Message,
                PhoneNumber = o.PhoneNumber,
                PostCode = o.PostCode,
                OrderedAt = o.OrderedAt,
                ReceiverName = o.ReceiverName,
                UsedPoints = o.UsedPoints,
                State = o.State.ToString(),
                InvoiceNumber = o.InvoiceNumber,
                PaymentId = o.PaymentId,
                UserId = o.UserId,
                DeliveryId = o.DeliveryId
            };
            Expression<Func<Payment, PaymentRead>> paymentToReadExpression = p => new PaymentRead() { Id = p.Id, BalanceAmount = p.BalanceAmount, ImpUid = p.ImpUid, PaidAmount = p.PaidAmount, Status = p.Status.ToString() };
            Expression<Func<Point, PointRead>> pointToReadExpression = p => new PointRead() { Id = p.Id, Amount = p.Amount, Balance = p.Balance, ExpiredAt = p.ExpiredAt, UserId = p.UserId };
            Expression<Func<Publisher, PublisherRead>> publisherToReadExpression = p => new PublisherRead() { Id = p.Id, Introduce = p.Introduce, Name = p.Name };
            Expression<Func<Role, RoleRead>> roleToReadExpression = r => new RoleRead() { Id = r.Id, Name = r.Name, Priority = r.Priority };
            Expression<Func<Translator, TranslatorRead>> translatorToReadExpression = t => new TranslatorRead() { Id = t.Id, Introduce = t.Introduce, Name = t.Name };
            Expression<Func<UserAddress, UserAddressRead>> userAddressToReadExpression = u => new UserAddressRead() { Id = u.Id, Address = u.Address, IsDefault = u.IsDefault, PostCode = u.PostCode, UserId = u.UserId };
            Expression<Func<User, UserRead>> userToReadExpression = u => new UserRead()
            {
                Id = u.Id,
                Email = u.Email,
                IsExpired = u.IsExpired,
                IsLocked = u.IsLocked,
                MembershipId = u.MembershipId,
                Name = u.Name,
                SignupAt = u.SignupAt,
                SignupIp = u.SignupIp,
                LastLoginDate = u.LastLoginDate,
                LastLoginIp = u.LastLoginIp,
            };

            referenceExpressionProviderBuilder.Add(authorToReadExpression);
            referenceExpressionProviderBuilder.Add(bookDisplayToReadExpression);
            referenceExpressionProviderBuilder.Add(bookToReadExpression);
            referenceExpressionProviderBuilder.Add(deliveryToReadExpression);
            referenceExpressionProviderBuilder.Add(goodsToReadExpression);
            referenceExpressionProviderBuilder.Add(goodsCartToReadExpression);
            referenceExpressionProviderBuilder.Add(goodsCategoryToReadExpression);
            referenceExpressionProviderBuilder.Add(goodsOrderToReadExpression);
            referenceExpressionProviderBuilder.Add(goodsReviewToReadExpression);
            referenceExpressionProviderBuilder.Add(membershipToReadExpression);
            referenceExpressionProviderBuilder.Add(oAuthIdToReadExpression);
            referenceExpressionProviderBuilder.Add(oAuthProviderToReadExpression);
            referenceExpressionProviderBuilder.Add(orderSetToReadExpression);
            referenceExpressionProviderBuilder.Add(paymentToReadExpression);
            referenceExpressionProviderBuilder.Add(pointToReadExpression);
            referenceExpressionProviderBuilder.Add(publisherToReadExpression);
            referenceExpressionProviderBuilder.Add(roleToReadExpression);
            referenceExpressionProviderBuilder.Add(translatorToReadExpression);
            referenceExpressionProviderBuilder.Add(userAddressToReadExpression);
            referenceExpressionProviderBuilder.Add(userToReadExpression);

            MappedExpressionProvider.MappedExpressionProvider referenceExpressionProvider = referenceExpressionProviderBuilder.Build(maxDepth, referenceRecursion);

            return referenceExpressionProvider;
        }
    }
}