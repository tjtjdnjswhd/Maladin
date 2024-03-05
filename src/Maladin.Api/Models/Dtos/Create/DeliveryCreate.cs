using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class DeliveryCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}