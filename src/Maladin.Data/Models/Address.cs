namespace Maladin.Data.Models
{
    public class UserAddress : EntityBase
    {
        public required int UserId { get; set; }
        public required string Address { get; set; }
        public required bool IsDefault { get; set; }

        public User User { get; set; }
    }
}