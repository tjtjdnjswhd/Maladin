namespace Maladin.Api.Models.Dtos.Update
{
    public class PointUpdate
    {
        public required int Balance { get; set; }

        public required int Amount { get; set; }

        public required int UserId { get; set; }
    }
}