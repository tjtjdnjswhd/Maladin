namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsCartCreate
    {
        public required int Count { get; set; }

        public required int UserId { get; set; }

        public required int GoodsId { get; set; }
    }
}