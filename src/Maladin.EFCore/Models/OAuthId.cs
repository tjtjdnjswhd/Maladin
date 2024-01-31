using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("OAuthId")]
    public class OAuthId(string nameIdentifier, int providerId, int userId) : EntityBase
    {
        [Required]
        public string NameIdentifier { get; private set; } = nameIdentifier;

        [Required]
        public int ProviderId { get; private set; } = providerId;

        [Required]
        public int UserId { get; private set; } = userId;

        public OAuthProvider Provider { get; }

        public User User { get; }
    }
}