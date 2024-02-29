namespace Maladin.Api.Models.Dtos.Update
{
    public class GoodsCategoryUpdate
    {
        public required string Name { get; set; }

        public int? ParentId { get; set; }
    }
}