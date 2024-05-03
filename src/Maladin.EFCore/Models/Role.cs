using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Role")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Priority), IsUnique = true)]
    public class Role(string name, int priority) : EntityBase
    {
        [Required]
        [Unicode]
        public string Name { get; set; } = name;

        [Required]
        public int Priority { get; set; } = priority;

        public List<User> Users { get; } = [];
    }
}