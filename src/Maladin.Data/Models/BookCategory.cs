namespace Maladin.Data.Models
{
    public class BookCategory : EntityBase
    {
        public int? ParentId { get; set; }
        public required string Name { get; set; }

        public List<BookDisplay> BookDisplays { get; set; }
        public BookCategory Parent { get; set; }
        public List<BookCategory> Children { get; set; }
    }
}