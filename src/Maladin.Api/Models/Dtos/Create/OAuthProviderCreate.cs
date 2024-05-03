using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class OAuthProviderCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}