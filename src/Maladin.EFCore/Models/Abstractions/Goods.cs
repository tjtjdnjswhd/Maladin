using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Maladin.EFCore.Models.Abstractions
{
    public abstract class Goods : EntityBase
    {
        protected Goods(string name, string? overview, int price, int categoryId)
        {
            Name = name;
            Overview = overview;
            Price = price;
            CategoryId = categoryId;
        }

        protected Goods(string name, string? overview, int price, GoodsCategory category)
        {
            Name = name;
            Overview = overview;
            Price = price;
            Category = category;
        }

        [Required]
        [Unicode]
        public string Name { get; set; }

        [Unicode]
        public string? Overview { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public GoodsCategory Category { get; set; }

        public List<GoodsCart> Carts { get; } = [];

        public List<GoodsOrder> Orders { get; } = [];

        public List<GoodsReview> Reviews { get; } = [];
    }
}