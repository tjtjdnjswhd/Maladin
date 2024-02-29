namespace Maladin.Api.Models.Dtos.Read.Abstractions
{
    public abstract class GoodsRead : IDtoKind
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? Overview { get; set; }

        public required int Price { get; set; }

        public required int CategoryId { get; set; }

        public required string Kind { get; set; }
    }
}