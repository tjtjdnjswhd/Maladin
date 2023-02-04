namespace Maladin.Data.Models
{
    public class Role : EntityBase
    {
        public required string Name { get; set; }
        public required int Priority { get; set; }

        public List<User> Users { get; set; }
    }
}