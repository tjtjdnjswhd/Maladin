using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("UserAddress")]
    public class UserAddress : EntityBase
    {
        public UserAddress(string address, string postCode, bool isDefault, int userId)
        {
            Address = address;
            PostCode = postCode;
            IsDefault = isDefault;
            UserId = userId;
        }

        public UserAddress(string address, string postCode, bool isDefault, User user)
        {
            Address = address;
            PostCode = postCode;
            IsDefault = isDefault;
            User = user;
        }

        [Unicode]
        public string Address { get; set; }

        public string PostCode { get; set; }

        public bool IsDefault { get; set; }

        public int UserId { get; private set; }

        public User User { get; }
    }
}