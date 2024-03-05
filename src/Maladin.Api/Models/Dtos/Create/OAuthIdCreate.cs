using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class OAuthIdCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string NameIdentifier { get; set; }

        [EntityId]
        public required int ProviderId { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}