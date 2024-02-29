namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsCategoryCreate
    {
        public required string Name { get; set; }

        public int? ParentId { get; set; }
    }
}