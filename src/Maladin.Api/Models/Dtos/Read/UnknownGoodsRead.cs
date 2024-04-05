using Maladin.Api.Models.Dtos.Read.Abstractions;

namespace Maladin.Api.Models.Dtos.Read
{
    public class UnknownGoodsRead : GoodsRead
    {
        public override EGoodsKind Kind => EGoodsKind.Unknown;
    }
}
