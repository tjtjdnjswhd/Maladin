using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Maladin.EFCore.Models
{
    [Table("User")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : EntityBase
    {
        public User(string name, string email, IPAddress signupIp, int roleId, int membershipId)
        {
            Name = name;
            Email = email;
            SignupIp = signupIp;
            RoleId = roleId;
            MembershipId = membershipId;
        }

        public User(string name, string email, IPAddress signupIp, Role role, Membership membership)
        {
            Name = name;
            Email = email;
            SignupIp = signupIp;
            Role = role;
            Membership = membership;
        }

        [Required]
        [Unicode]
        public string Name { get; set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset SignupAt { get; private set; }

        [Required]
        public IPAddress SignupIp { get; private set; }

        public DateTimeOffset? LastLoginDate { get; set; }

        public IPAddress? LastLoginIp { get; set; }

        [Required]
        public bool IsExpired { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int MembershipId { get; set; }

        public Role Role { get; set; }

        public Membership Membership { get; set; }

        public List<OAuthId> OAuthIds { get; } = [];

        public List<Point> Points { get; } = [];

        public List<UserAddress> Addresses { get; } = [];

        public List<OrderSet> Orders { get; } = [];

        public List<GoodsCart> Cart { get; } = [];

        public List<GoodsReview> Reviews { get; } = [];
    }
}