namespace Maladin.Api.Models.Dtos.Update
{
    public class UserAddressUpdate
    {
        public required string Address { get; set; }

        public required string PostCode { get; set; }

        public required bool IsDefault { get; set; }
    }
}