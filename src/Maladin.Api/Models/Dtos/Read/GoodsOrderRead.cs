namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsOrderRead
    {
        public required int Id { get; set; }

        public required int OrderQty { get; set; }

        public required int CancelQty { get; set; }

        public required int OrderSetId { get; set; }

        public required int GoodsId { get; set; }
    }
}