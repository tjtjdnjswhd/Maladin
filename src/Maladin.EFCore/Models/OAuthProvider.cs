using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("OAuthProvider")]
    [Index(nameof(Name), IsUnique = true)]
    public class OAuthProvider(string name) : EntityBase
    {
        public string Name { get; set; } = name;

        public List<OAuthId> OAuthIds { get; } = [];
    }
}