namespace Maladin.Data.Models
{
    public sealed class Author : EntityBase
    {
        public required string Name { get; set; }
#nullable enable
        public string? Introduce { get; set; }
#nullable restore

        public List<BookDisplay> BookDisplays { get; set; }
    }
}