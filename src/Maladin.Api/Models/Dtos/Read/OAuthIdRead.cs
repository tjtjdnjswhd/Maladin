using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class OAuthIdRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string NameIdentifier { get; set; }

        [EntityId]
        public required int ProviderId { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}