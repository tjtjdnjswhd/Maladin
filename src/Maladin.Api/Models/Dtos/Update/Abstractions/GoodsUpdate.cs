namespace Maladin.Api.Models.Dtos.Update.Abstractions
{
    public class GoodsUpdate : IDtoKind
    {
        public required string Name { get; set; }

        public string? Overview { get; set; }

        public required int Price { get; set; }

        public required int CategoryId { get; set; }

        public required string Kind { get; set; }
    }
}