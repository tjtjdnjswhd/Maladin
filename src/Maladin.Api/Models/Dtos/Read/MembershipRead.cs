namespace Maladin.Api.Models.Dtos.Read
{
    public class MembershipRead
    {
        public required int Id { get; set; }

        public required int Level { get; set; }

        public required int PointPercentage { get; set; }
    }
}