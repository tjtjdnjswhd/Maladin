namespace Maladin.Data.Models
{
    public class Point : EntityBase
    {
        public required int UserId { get; set; }
        public required int Balance { get; set; }
        public required int Amount { get; set; }
        public required DateTimeOffset ExpireAt { get; set; }

        public User User { get; set; }
    }
}