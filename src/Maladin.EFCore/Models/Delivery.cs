using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Delivery")]
    public class Delivery(string name) : EntityBase
    {
        [Required]
        [Unicode]
        public string Name { get; set; } = name;

        public List<OrderSet> Orders { get; } = [];
    }
}