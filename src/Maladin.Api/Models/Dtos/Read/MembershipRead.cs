using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class MembershipRead : ReadBase
    {
        [Range(0, int.MaxValue)]
        public required int Level { get; set; }

        [Range(0, int.MaxValue)]
        public required int PointPercentage { get; set; }

        [JsonIgnore]
        public List<UserRead>? Users { get; private set; }
    }
}