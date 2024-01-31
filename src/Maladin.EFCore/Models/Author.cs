using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Author")]
    public class Author(string name, string introduce) : Writer(name, introduce)
    {
    }
}