using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Membership")]
    [Index(nameof(Level), IsUnique = true)]
    public class Membership(int level, int pointPercentage) : EntityBase
    {
        [Required]
        public int Level { get; set; } = level;

        [Required]
        public int PointPercentage { get; set; } = pointPercentage;

        public List<User> Users { get; } = [];
    }
}