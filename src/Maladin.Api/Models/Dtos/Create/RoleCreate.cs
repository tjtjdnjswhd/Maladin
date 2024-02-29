namespace Maladin.Api.Models.Dtos.Create
{
    public class RoleCreate
    {
        public required string Name { get; set; }

        public required int Priority { get; set; }
    }
}