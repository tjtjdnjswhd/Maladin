namespace Maladin.Api.Models.Dtos.Read
{
    public class BookRead
    {
        public required int Id { get; set; }

        public required int Stock { get; set; }

        public required string Isbn { get; set; }

        public required int Sales { get; set; }
    }
}