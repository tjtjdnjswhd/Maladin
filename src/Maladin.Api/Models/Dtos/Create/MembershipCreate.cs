namespace Maladin.Api.Models.Dtos.Create
{
    public class MembershipCreate
    {
        public required int Level { get; set; }

        public required int PointPercentage { get; set; }
    }
}