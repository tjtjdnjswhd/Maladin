namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsOrderCreate
    {
        public required int Price { get; set; }

        public required int OrderQty { get; set; }

        public required int CancelQty { get; set; }

        public required int OrderSetId { get; set; }

        public required int GoodsId { get; set; }
    }
}