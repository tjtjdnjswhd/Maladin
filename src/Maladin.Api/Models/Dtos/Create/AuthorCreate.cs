namespace Maladin.Api.Models.Dtos.Create
{
    public class AuthorCreate
    {
        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}