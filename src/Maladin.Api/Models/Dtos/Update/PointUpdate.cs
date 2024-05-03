using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class PointUpdate
    {
        [Range(1, int.MaxValue)]
        public required int Amount { get; set; }
    }
}