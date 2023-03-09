#nullable disable

using Maladin.Service.Models.Enums;

namespace Maladin.Service.Models
{
    public class VirtualBankRefundInfo
    {
        public string RefundHolder { get; set; }
        public EBankCode RefundBankCode { get; set; }
        public string RefundAccount { get; set; }
        public string RefundTel { get; set; }
    }
}