using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("GoodsOrder")]
    public class GoodsOrder : EntityBase
    {
        public GoodsOrder(int price, int orderQty, int orderSetId, int goodsId) : this(price, orderQty)
        {
            OrderSetId = orderSetId;
            GoodsId = goodsId;
        }

        public GoodsOrder(int price, int orderQty, OrderSet orderSet, Goods goods) : this(price, orderQty)
        {
            OrderSet = orderSet;
            Goods = goods;
        }

        private GoodsOrder(int price, int orderQty)
        {
            Price = price;
            OrderQty = orderQty;
            CancelQty = 0;
        }

        [Required]
        public int Price { get; private set; }

        [Required]
        public int OrderQty { get; private set; }

        [Required]
        public int CancelQty { get; set; }

        [Required]
        public int OrderSetId { get; private set; }

        [Required]
        public int GoodsId { get; private set; }

        public OrderSet OrderSet { get; }

        public Goods Goods { get; }
    }
}