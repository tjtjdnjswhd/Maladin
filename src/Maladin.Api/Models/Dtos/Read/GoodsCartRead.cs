namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsCartRead
    {
        public required int Id { get; set; }

        public required int Count { get; set; }

        public required int UserId { get; set; }

        public required int GoodsId { get; set; }
    }
}