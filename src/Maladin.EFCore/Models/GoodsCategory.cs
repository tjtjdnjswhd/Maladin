using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("GoodsCategory")]
    public class GoodsCategory(string name) : EntityBase
    {
        public GoodsCategory(string name, int parentId) : this(name)
        {
            ParentId = parentId;
        }

        [Required]
        [Unicode]
        public string Name { get; set; } = name;

        public int? ParentId { get; set; }

        public GoodsCategory? Parent { get; set; }

        public List<GoodsCategory> ChildCategories { get; } = [];

        public List<Goods> GoodsList { get; } = [];
    }
}