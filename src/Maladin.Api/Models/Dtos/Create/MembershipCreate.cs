using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class MembershipCreate
    {
        public required int Level { get; set; }

        [Range(0, int.MaxValue)]
        public required int PointPercentage { get; set; }
    }
}