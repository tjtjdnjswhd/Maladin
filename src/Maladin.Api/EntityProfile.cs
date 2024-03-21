using AutoMapper;

using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;

namespace Maladin.Api
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Author, AuthorRead>();
            CreateMap<BookDisplay, BookDisplayRead>();
            CreateMap<Book, BookRead>();
            CreateMap<Delivery, DeliveryRead>();
            CreateMap<Goods, GoodsRead>();
            CreateMap<GoodsCart, GoodsCartRead>();
            CreateMap<GoodsCategory, GoodsCategoryRead>();
            CreateMap<GoodsOrder, GoodsOrderRead>();
            CreateMap<GoodsReview, GoodsReviewRead>();
            CreateMap<Membership, MembershipRead>();
            CreateMap<OAuthId, OAuthIdRead>();
            CreateMap<OAuthProvider, OAuthProviderRead>();
            CreateMap<OrderSet, OrderSetRead>();
            CreateMap<Payment, PaymentRead>();
            CreateMap<Point, PointRead>();
            CreateMap<Publisher, PublisherRead>();
            CreateMap<Role, RoleRead>();
            CreateMap<Translator, TranslatorRead>();
            CreateMap<UserAddress, UserAddressRead>();
            CreateMap<User, UserRead>();
        }
    }
}