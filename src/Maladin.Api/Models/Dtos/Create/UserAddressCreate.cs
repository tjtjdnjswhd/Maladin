namespace Maladin.Api.Models.Dtos.Create
{
    public class UserAddressCreate
    {
        public required string Address { get; set; }

        public required string PostCode { get; set; }

        public required bool IsDefault { get; set; }

        public required int UserId { get; set; }
    }
}