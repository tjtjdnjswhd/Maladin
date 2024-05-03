using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Maladin.EFCore.Models.Abstractions
{
    public abstract class Writer(string name, string? introduce) : EntityBase
    {
        [Required]
        [Unicode]
        public string Name { get; set; } = name;

        [Unicode]
        public string? Introduce { get; set; } = introduce;

        public List<BookDisplay> Books { get; } = [];
    }
}