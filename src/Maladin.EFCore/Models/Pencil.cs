using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Maladin.EFCore.Models
{
    public class Pencil : Goods
    {
        public Pencil(string name, string? overview, int price, int categoryId, string maker) : base(name, overview, price, categoryId)
        {
            Maker = maker;
        }

        public Pencil(string name, string? overview, int price, GoodsCategory category, string maker) : base(name, overview, price, category)
        {
            Maker = maker;
        }

        [Required]
        [Unicode]
        public string Maker { get; set; }
    }
}