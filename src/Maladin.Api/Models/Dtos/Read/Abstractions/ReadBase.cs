using Maladin.Api.Validation;

namespace Maladin.Api.Models.Dtos.Read.Abstractions
{
    public class ReadBase
    {
        [EntityId]
        public required int Id { get; set; }
    }
}