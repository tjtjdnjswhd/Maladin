namespace Maladin.Service.Models
{
    public sealed class OrderContext
    {
        public OrderContext(int userId, Dictionary<int, int> qtyByBookId, int pointAmount, string address, string postCode, string reciverName, string? message, string phoneNumber)
        {
            UserId = userId;
            QtyByBookId = qtyByBookId;
            PointAmount = pointAmount;
            Address = address;
            PostCode = postCode;
            ReciverName = reciverName;
            Message = message;
            PhoneNumber = phoneNumber;
        }

        public int UserId { get; set; }
        public Dictionary<int, int> QtyByBookId { get; init; }
        public int PointAmount { get; init; }
        public string Address { get; init; }
        public string PostCode { get; init; }
        public string ReciverName { get; init; }
        public string? Message { get; init; }
        public string PhoneNumber { get; init; }
    }
}