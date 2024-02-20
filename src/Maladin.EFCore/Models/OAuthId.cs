using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("OAuthId")]
    public class OAuthId : EntityBase
    {
        public OAuthId(string nameIdentifier, OAuthProvider provider, User user)
        {
            NameIdentifier = nameIdentifier;
            Provider = provider;
            User = user;
        }

        public OAuthId(string nameIdentifier, int providerId, int userId)
        {
            NameIdentifier = nameIdentifier;
            ProviderId = providerId;
            UserId = userId;
        }

        [Required]
        public string NameIdentifier { get; private set; }

        [Required]
        public int ProviderId { get; private set; }

        [Required]
        public int UserId { get; private set; }

        public OAuthProvider Provider { get; }

        public User User { get; }
    }
}