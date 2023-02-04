namespace Maladin.Data.Models
{
    public class Delivery : EntityBase
    {
        public required string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}