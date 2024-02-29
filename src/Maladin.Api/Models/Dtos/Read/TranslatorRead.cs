namespace Maladin.Api.Models.Dtos.Read
{
    public class TranslatorRead
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}