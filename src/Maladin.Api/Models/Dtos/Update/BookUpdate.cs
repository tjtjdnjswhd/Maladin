namespace Maladin.Api.Models.Dtos.Update
{
    public class BookUpdate
    {
        public required int Stock { get; set; }

        public required string Isbn { get; set; }

        public required int Sales { get; set; }
    }
}