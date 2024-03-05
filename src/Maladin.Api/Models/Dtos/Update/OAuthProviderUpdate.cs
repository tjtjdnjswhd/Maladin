using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class OAuthProviderUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}