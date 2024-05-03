using Maladin.EFCore.Models.Abstractions;
using Maladin.EFCore.Models.Enums;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("OrderSet")]
    public class OrderSet : EntityBase, IUserRelationEntity
    {
        public OrderSet(int usedPoints, string address, string postCode, string receiverName, string? message, string phoneNumber, int userId)
        {
            UsedPoints = usedPoints;
            Address = address;
            PostCode = postCode;
            ReceiverName = receiverName;
            Message = message;
            PhoneNumber = phoneNumber;
            UserId = userId;
        }

        public OrderSet(int usedPoints, string address, string postCode, string receiverName, string? message, string phoneNumber, User user)
        {
            UsedPoints = usedPoints;
            Address = address;
            PostCode = postCode;
            ReceiverName = receiverName;
            Message = message;
            PhoneNumber = phoneNumber;
            User = user;
        }

        [Required]
        public Guid Uid { get; set; }

        [Required]
        public int UsedPoints { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset OrderedAt { get; set; }

        [Required]
        [Unicode]
        public string Address { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [Unicode]
        public string ReceiverName { get; set; }

        [Unicode]
        public string? Message { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? InvoiceNumber { get; set; }

        [Required]
        public EOrderSetStatus State { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? DeliveryId { get; set; }

        [Required]
        public int PaymentId { get; set; }

        public User User { get; }

        public Delivery? Delivery { get; set; }

        public Payment Payment { get; set; }

        public List<GoodsOrder> GoodsOrders { get; } = [];
    }
}