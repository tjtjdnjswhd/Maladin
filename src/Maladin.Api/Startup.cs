using AspNet.Security.OAuth.KakaoTalk;
using AspNet.Security.OAuth.Naver;

using AutoMapper.Extensions.ExpressionMapping;

using LinqExpressionParser.AspNetCore.Extensions;

using Maladin.Api.Constants;
using Maladin.Api.Extensions;
using Maladin.Api.ModelBinders;
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
using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
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
                options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientId") ?? throw new NullReferenceException();
                options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientSecret") ?? throw new NullReferenceException();
                options.AuthorizationEndpoint += "?prompt=consent";
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
                Dictionary<string, DtoTypes> dtoTypesByKind = new(StringComparer.OrdinalIgnoreCase)
                {
                    { "bookDisplay", new DtoTypes(typeof(BookDisplayRead), typeof(BookDisplayCreate), typeof(BookDisplayUpdate)) }
                };
                options.ModelBinderProviders.Insert(0, new GoodsModelBinderProvider(dtoTypesByKind));
            });

            builder.Services.AddExpressionParse();

            //Automapper profile
            builder.Services.AddAutoMapper(cnf => cnf.AddExpressionMapping(), typeof(EntityProfile));

            //Entity configuration
            builder.Services.AddScoped<IEntityConfigurationService, EntityConfigurationService>();

            #region QueryOptions
            builder.Services.AddEntityQueryOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>(options =>
            {
                options.EntityToReadExpression = _ => a => new AuthorRead() { Id = a.Id, Introduce = a.Introduce, Name = a.Name };
                options.CreateFunc = dto => new Author(dto.Name, dto.Introduce);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                    entity.Introduce = dto.Introduce;
                };
            });

            builder.Services.AddEntityQueryOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>(options =>
            {
                options.EntityToReadExpression = _ => b => new BookDisplayRead()
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
                options.CreateFunc = dto => new BookDisplay(dto.Name, dto.Overview, dto.Price, dto.PaperSize, dto.PageCount, dto.CoverUrl, dto.PublishedAt, dto.BookId, dto.AuthorId, dto.TranslatorId, dto.PublisherId, dto.CategoryId);
                options.UpdateFunc = (entity, dto) =>
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
                };
            });

            builder.Services.AddEntityQueryOptions<Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.EntityToReadExpression = _ => b => new BookRead() { Id = b.Id, Isbn = b.Isbn, Sales = b.Sales, Stock = b.Stock };
                options.CreateFunc = dto => new Book(dto.Stock, dto.Isbn, dto.Sales);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Stock = dto.Stock;
                    entity.Isbn = dto.Isbn;
                    entity.Sales = dto.Sales;
                };
            });

            builder.Services.AddEntityQueryOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.EntityToReadExpression = _ => d => new DeliveryRead() { Id = d.Id, Name = d.Name };
                options.CreateFunc = dto => new Delivery(dto.Name);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                };
            });

            builder.Services.AddEntityQueryOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(options =>
            {
                options.EntityToReadExpression = _ => g => g is BookDisplay ?
                    new BookDisplayRead()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Overview = g.Overview,
                        Price = g.Price,
                        CategoryId = g.CategoryId,
                        PageCount = ((BookDisplay)g).PageCount,
                        PaperSize = ((BookDisplay)g).PaperSize,
                        PublishedAt = ((BookDisplay)g).PublishedAt,
                        CoverUrl = ((BookDisplay)g).CoverUrl,
                        AuthorId = ((BookDisplay)g).AuthorId,
                        BookId = ((BookDisplay)g).BookId,
                        PublisherId = ((BookDisplay)g).PublisherId,
                        TranslatorId = ((BookDisplay)g).TranslatorId,
                    }
                    :
                    null!;
                options.CreateFunc = dto => dto switch
                {
                    BookDisplayCreate bookDisplay => new BookDisplay(bookDisplay.Name, bookDisplay.Overview, bookDisplay.Price, bookDisplay.PaperSize, bookDisplay.PageCount, bookDisplay.CoverUrl, bookDisplay.PublishedAt, bookDisplay.BookId, bookDisplay.AuthorId, bookDisplay.TranslatorId, bookDisplay.PublisherId, bookDisplay.CategoryId),
                    _ => throw new ArgumentException("Invalid goods type")
                };
                options.UpdateFunc = (entity, dto) =>
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
                };
            });

            builder.Services.AddEntityQueryOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.EntityToReadExpression = _ => g => new GoodsCartRead() { Id = g.Id, Count = g.Count, GoodsId = g.GoodsId, UserId = g.UserId };
                options.CreateFunc = dto => new GoodsCart(dto.Count, dto.UserId, dto.GoodsId);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Count = dto.Count;
                };
            });

            builder.Services.AddEntityQueryOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(options =>
            {
                options.EntityToReadExpression = _ => g => new GoodsCategoryRead() { Id = g.Id, Name = g.Name, ParentId = g.ParentId };
                options.CreateFunc = dto => dto.ParentId is null ? new GoodsCategory(dto.Name) : new GoodsCategory(dto.Name, dto.ParentId.Value);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                    entity.ParentId = dto.ParentId;
                };
            });

            builder.Services.AddEntityQueryOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(options =>
            {
                options.EntityToReadExpression = _ => g => new GoodsOrderRead() { Id = g.Id, CancelQty = g.CancelQty, GoodsId = g.GoodsId, OrderQty = g.OrderQty, OrderSetId = g.OrderSetId };
                options.CreateFunc = dto => new GoodsOrder(dto.Price, dto.OrderQty, dto.OrderSetId, dto.GoodsId);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.CancelQty = dto.CancelQty;
                };
            });

            builder.Services.AddEntityQueryOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(options =>
            {
                options.EntityToReadExpression = _ => g => new GoodsReviewRead() { Id = g.Id, CreatedAt = g.CreatedAt, GoodsId = g.GoodsId, Content = g.Content, Rating = g.Rating, UserId = g.UserId };
                options.CreateFunc = dto => new GoodsReview(dto.Content, dto.Rating, dto.UserId, dto.GoodsId);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Content = dto.Content;
                };
            });

            builder.Services.AddEntityQueryOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(options =>
            {
                options.EntityToReadExpression = _ => m => new MembershipRead() { Id = m.Id, Level = m.Level, PointPercentage = m.PointPercentage };
                options.CreateFunc = dto => new Membership(dto.Level, dto.PointPercentage);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Level = dto.Level;
                    entity.PointPercentage = dto.PointPercentage;
                };
            });

            builder.Services.AddEntityQueryOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(options =>
            {
                options.EntityToReadExpression = _ => o => new OAuthIdRead() { Id = o.Id, NameIdentifier = o.NameIdentifier, ProviderId = o.ProviderId, UserId = o.UserId };
                options.CreateFunc = dto => new OAuthId(dto.NameIdentifier, dto.ProviderId, dto.UserId);
                options.UpdateFunc = (entity, dto) =>
                {
                };
            });

            builder.Services.AddEntityQueryOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(options =>
            {
                options.EntityToReadExpression = _ => o => new OAuthProviderRead() { Id = o.Id, Name = o.Name };
                options.CreateFunc = dto => new OAuthProvider(dto.Name);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                };
            });

            builder.Services.AddEntityQueryOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(options =>
            {
                options.EntityToReadExpression = _ => o => new OrderSetRead()
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
                options.CreateFunc = dto => new OrderSet(dto.UsedPoints, dto.Address, dto.PostCode, dto.ReceiverName, dto.Message, dto.PhoneNumber, dto.UserId);
                options.UpdateFunc = (entity, dto) =>
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
                };
            });

            builder.Services.AddEntityQueryOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(options =>
            {
                options.EntityToReadExpression = _ => p => new PaymentRead() { Id = p.Id, BalanceAmount = p.BalanceAmount, ImpUid = p.ImpUid, PaidAmount = p.PaidAmount, Status = p.Status.ToString() };
                options.CreateFunc = dto => new Payment(Enum.Parse<EPaymentStatus>(dto.Status));
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Status = Enum.Parse<EPaymentStatus>(dto.Status);
                    entity.BalanceAmount = dto.BalanceAmount;
                    entity.PaidAmount = dto.PaidAmount;
                    entity.ImpUid = dto.ImpUid;
                };
            });

            builder.Services.AddEntityQueryOptions<Point, PointRead, PointCreate, PointUpdate>(options =>
            {
                options.EntityToReadExpression = _ => p => new PointRead() { Id = p.Id, Amount = p.Amount, Balance = p.Balance, ExpiredAt = p.ExpiredAt, UserId = p.UserId };
                options.CreateFunc = dto => new Point(dto.Amount, dto.UserId);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Amount = dto.Amount;
                };
            });

            builder.Services.AddEntityQueryOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(options =>
            {
                options.EntityToReadExpression = _ => p => new PublisherRead() { Id = p.Id, Introduce = p.Introduce, Name = p.Name };
                options.CreateFunc = dto => new Publisher(dto.Name, dto.Introduce);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                    entity.Introduce = dto.Introduce;
                };
            });

            builder.Services.AddEntityQueryOptions<Role, RoleRead, RoleCreate, RoleUpdate>(options =>
            {
                options.EntityToReadExpression = _ => r => new RoleRead() { Id = r.Id, Name = r.Name, Priority = r.Priority };
                options.CreateFunc = dto => new Role(dto.Name, dto.Priority);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                    entity.Priority = dto.Priority;
                };
            });

            builder.Services.AddEntityQueryOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(options =>
            {
                options.EntityToReadExpression = _ => t => new TranslatorRead() { Id = t.Id, Introduce = t.Introduce, Name = t.Name };
                options.CreateFunc = dto => new Translator(dto.Name, dto.Introduce);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Name = dto.Name;
                    entity.Introduce = dto.Introduce;
                };
            });

            builder.Services.AddEntityQueryOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(options =>
            {
                options.EntityToReadExpression = _ => u => new UserAddressRead() { Id = u.Id, Address = u.Address, IsDefault = u.IsDefault, PostCode = u.PostCode, UserId = u.UserId };
                options.CreateFunc = dto => new UserAddress(dto.Address, dto.PostCode, dto.IsDefault, dto.UserId);
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.Address = dto.Address;
                    entity.PostCode = dto.PostCode;
                    entity.IsDefault = dto.IsDefault;
                };
            });

            builder.Services.AddEntityQueryOptions<User, UserRead, UserCreate, UserUpdate>(options =>
            {
                options.EntityToReadExpression = _ => u => new UserRead()
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
                options.CreateFunc = dto => throw new NotImplementedException();
                options.UpdateFunc = (entity, dto) =>
                {
                    entity.IsExpired = dto.IsExpired;
                    entity.IsLocked = dto.IsLocked;
                    entity.MembershipId = dto.MembershipId;
                };
            });
            #endregion

            #region Authorization
            builder.Services.AddEntityAuthorizeOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Book, BookRead, BookCreate, BookUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAdmin());
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(options =>
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

            builder.Services.AddEntityAuthorizeOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(options =>
            {
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<GoodsCart>(context, entityId);
            });


            builder.Services.AddEntityAuthorizeOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<OAuthId>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<OrderSet>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<OrderSet>(context, entityId);
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(options =>
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

            builder.Services.AddEntityAuthorizeOptions<Point, PointRead, PointCreate, PointUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<Point>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<Point>(context, entityId);
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Role, RoleRead, RoleCreate, RoleUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAdmin());
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(options =>
            {
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, _, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
            });

            builder.Services.AddEntityAuthorizeOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(options =>
            {
                options.BeforeReadAuthorize = context => ValueTask.FromResult(context.User.IsAuthenticated());
                options.ReadAuthorize = async (context, read) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, read.Id);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAuthenticated());
                options.UpdateAuthorize = async (context, entityId, _) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, entityId);
                options.DeleteAuthorize = async (context, entityId) => context.User.IsAdmin() || await IsUserIdMatch<UserAddress>(context, entityId);
            });

            builder.Services.AddEntityAuthorizeOptions<User, UserRead, UserCreate, UserUpdate>(options =>
            {
                options.ReadAuthorize = (context, read) => ValueTask.FromResult(context.User.IsAdmin() || context.TryGetUserId(out int userId) && read.Id == userId);
                options.CreateAuthorize = (context, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.UpdateAuthorize = (context, entityId, _) => ValueTask.FromResult(context.User.IsAdmin());
                options.DeleteAuthorize = (context, entityId) => ValueTask.FromResult(context.User.IsAdmin());
            });
            #endregion

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
            return await dbContext.IsUserRelationAsync<T>(entityId, userId, context.RequestAborted);
        }
    }
}