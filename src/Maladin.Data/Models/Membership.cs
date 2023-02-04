namespace Maladin.Data.Models
{
    public class Membership : EntityBase
    {
        public required int Level { get; set; }
        public required int PointPercentage { get; set; }

        public List<User> Users { get; set; }
    }
}