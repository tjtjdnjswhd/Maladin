using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PointRead : ReadBase
    {
        [Range(0, int.MaxValue)]
        public required int Balance { get; set; }

        [Range(1, int.MaxValue)]
        public required int Amount { get; set; }

        public required DateTimeOffset ExpiredAt { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [JsonIgnore]
        public UserRead? User { get; private set; }
    }
}