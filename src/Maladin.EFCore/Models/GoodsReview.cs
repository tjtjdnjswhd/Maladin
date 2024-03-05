using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("GoodsReview")]
    public class GoodsReview : EntityBase
    {
        public GoodsReview(string? content, int rating, int userId, int goodsId)
        {
            Content = content;
            Rating = rating;
            UserId = userId;
            GoodsId = goodsId;
        }

        public GoodsReview(string? content, int rating, User user, Goods goods)
        {
            Content = content;
            Rating = rating;
            User = user;
            Goods = goods;
        }

        [Unicode]
        public string? Content { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedAt { get; private set; }

        [Required]
        public int UserId { get; private set; }

        [Required]
        public int GoodsId { get; private set; }

        public User User { get; }

        public Goods Goods { get; }
    }
}