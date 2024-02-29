namespace Maladin.Api.Models.Dtos.Read
{
    public class PublisherRead
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}