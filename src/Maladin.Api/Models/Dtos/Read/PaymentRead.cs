using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PaymentRead : ReadBase
    {
        public required string? ImpUid { get; set; }

        public required int? PaidAmount { get; set; }

        public required int? BalanceAmount { get; set; }

        [EnumDataType(typeof(EPaymentStatus))]
        public required string Status { get; set; }

        [JsonIgnore]
        public OrderSetRead? Order { get; }
    }
}