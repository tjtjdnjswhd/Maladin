namespace Maladin.Api.Models.Dtos.Update
{
    public class AuthorUpdate
    {
        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}