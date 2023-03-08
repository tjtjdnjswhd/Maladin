namespace Maladin.Service.Models
{
    public sealed class OrderAddContext
    {
        public OrderAddContext(int userId, Dictionary<int, int> qtyByBookId, int amountPoint, string address, string postCode, string reciverName, string? message, string phoneNumber)
        {
            UserId = userId;
            QtyByBookId = qtyByBookId;
            AmountPoint = amountPoint;
            Address = address;
            PostCode = postCode;
            ReciverName = reciverName;
            Message = message;
            PhoneNumber = phoneNumber;
        }

        public int UserId { get; set; }
        public Dictionary<int, int> QtyByBookId { get; init; }
        public int AmountPoint { get; init; }
        public string Address { get; init; }
        public string PostCode { get; init; }
        public string ReciverName { get; init; }
        public string? Message { get; init; }
        public string PhoneNumber { get; init; }
    }
}