namespace Maladin.Api.Models.Dtos.Create
{
    public class PointCreate
    {
        public required int Amount { get; set; }

        public required int UserId { get; set; }
    }
}