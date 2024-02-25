namespace Maladin.Api.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public required int Stock { get; set; }

        public required string Isbn { get; set; }

        public required int Sales { get; set; }
    }
}