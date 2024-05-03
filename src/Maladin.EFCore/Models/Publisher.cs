using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Publisher")]
    public class Publisher(string name, string? introduce) : Writer(name, introduce)
    {
    }
}
