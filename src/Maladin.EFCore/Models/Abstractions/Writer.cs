using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Maladin.EFCore.Models.Abstractions
{
    public abstract class Writer : EntityBase
    {
        protected Writer(string name, string? introduce)
        {
            Name = name;
            Introduce = introduce;
        }

        [Required]
        [Unicode]
        public string Name { get; set; }

        [Unicode]
        public string? Introduce { get; set; }

        public List<BookDisplay> Books { get; } = [];
    }
}