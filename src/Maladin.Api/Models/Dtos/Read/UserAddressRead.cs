namespace Maladin.Api.Models.Dtos.Read
{
    public class UserAddressRead
    {
        public int Id { get; set; }

        public required string Address { get; set; }

        public required string PostCode { get; set; }

        public required bool IsDefault { get; set; }

        public required int UserId { get; set; }
    }
}