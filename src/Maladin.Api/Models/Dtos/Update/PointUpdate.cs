using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class PointUpdate
    {
        [Range(0, int.MaxValue)]
        public required int Balance { get; set; }

        [Range(1, int.MaxValue)]
        public required int Amount { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}