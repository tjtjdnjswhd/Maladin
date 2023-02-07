namespace Maladin.Data.Models
{
    public sealed class Delivery : EntityBase
    {
        public required string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}