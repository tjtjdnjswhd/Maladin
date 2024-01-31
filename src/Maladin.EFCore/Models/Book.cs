using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Book")]
    public class Book(int stock, string isbn, int sales) : EntityBase
    {
        [Required]
        public int Stock { get; set; } = stock;

        [Required]
        public string Isbn { get; set; } = isbn;

        [Required]
        public int Sales { get; set; } = sales;

        public List<BookDisplay> BookDisplays { get; } = [];
    }
}