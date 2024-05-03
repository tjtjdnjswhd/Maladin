using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Translator")]
    public class Translator(string name, string? introduce) : Writer(name, introduce)
    {
    }
}