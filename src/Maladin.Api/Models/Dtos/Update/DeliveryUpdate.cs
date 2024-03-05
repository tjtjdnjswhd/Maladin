using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class DeliveryUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}