using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class MembershipRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Range(0, int.MaxValue)]
        public required int Level { get; set; }

        [Range(0, int.MaxValue)]
        public required int PointPercentage { get; set; }
    }
}