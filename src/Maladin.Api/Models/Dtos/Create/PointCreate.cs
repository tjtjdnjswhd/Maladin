using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class PointCreate
    {
        [Range(0, int.MaxValue)]
        public required int Amount { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}