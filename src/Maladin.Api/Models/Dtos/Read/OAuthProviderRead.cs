using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class OAuthProviderRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}