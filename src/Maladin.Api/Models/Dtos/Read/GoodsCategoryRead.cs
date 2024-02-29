namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsCategoryRead
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public GoodsCategoryRead? Parent { get; set; }
    }
}