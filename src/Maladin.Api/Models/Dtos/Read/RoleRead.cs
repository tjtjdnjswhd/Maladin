namespace Maladin.Api.Models.Dtos.Read
{
    public class RoleRead
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required int Priority { get; set; }
    }
}