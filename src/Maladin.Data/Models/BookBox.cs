namespace Maladin.Data.Models
{
    public class BookBox : EntityBase
    {
        public required int UserId { get; set; }
        public required int BookId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}