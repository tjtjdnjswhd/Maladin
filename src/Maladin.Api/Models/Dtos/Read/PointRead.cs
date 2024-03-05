using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PointRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Range(0, int.MaxValue)]
        public required int Balance { get; set; }

        [Range(1, int.MaxValue)]
        public required int Amount { get; set; }

        public required DateTimeOffset ExpiredAt { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}