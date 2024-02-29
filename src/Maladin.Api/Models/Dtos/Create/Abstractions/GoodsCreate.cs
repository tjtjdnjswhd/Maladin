namespace Maladin.Api.Models.Dtos.Create.Abstractions
{
    public abstract class GoodsCreate : IDtoKind
    {
        public required string Name { get; set; }

        public string? Overview { get; set; }

        public required int Price { get; set; }

        public required int CategoryId { get; set; }

        public required string Kind { get; set; }
    }
}