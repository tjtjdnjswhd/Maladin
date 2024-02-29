namespace Maladin.Api.Models.Dtos.Read
{
    public class PointRead
    {
        public required int Id { get; set; }

        public required int Balance { get; set; }

        public required int Amount { get; set; }

        public required DateTimeOffset ExpiredAt { get; set; }

        public required int UserId { get; set; }
    }
}