using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("GoodsCart")]
    public class GoodsCart : EntityBase, IUserRelationEntity
    {
        public GoodsCart(int count, int userId, int goodsId)
        {
            Count = count;
            UserId = userId;
            GoodsId = goodsId;
        }

        public GoodsCart(int count, User user, Goods goods)
        {
            Count = count;
            User = user;
            Goods = goods;
        }

        [Required]
        public int Count { get; set; }

        [Required]
        public int UserId { get; private set; }

        [Required]
        public int GoodsId { get; private set; }

        public User User { get; }

        public Goods Goods { get; }
    }
}