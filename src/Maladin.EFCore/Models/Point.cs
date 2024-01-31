using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Point")]
    public class Point : EntityBase
    {
        public Point(int amount, int userId)
        {
            Balance = amount;
            Amount = amount;
            UserId = userId;
        }

        public Point(int amount, User user)
        {
            Balance = amount;
            Amount = amount;
            User = user;
        }

        [Required]
        public int Balance { get; private set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTimeOffset ExpiredAt { get; private set; }

        [Required]
        public int UserId { get; private set; }

        public User User { get; }
    }
}