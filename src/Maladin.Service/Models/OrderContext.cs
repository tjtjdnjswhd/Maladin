using Maladin.Data.Models;

namespace Maladin.Service.Models
{
    public sealed class OrderContext
    {
        public OrderContext(Dictionary<Book, int> qtyByBook, int usedPoint, string address, string postCode, string reciverName, string? message, string phoneNumber)
        {
            QtyByBook = qtyByBook;
            UsedPoint = usedPoint;
            Address = address;
            PostCode = postCode;
            ReciverName = reciverName;
            Message = message;
            PhoneNumber = phoneNumber;
        }

        public Dictionary<Book, int> QtyByBook { get; init; }
        public int UsedPoint { get; init; }
        public string Address { get; init; }
        public string PostCode { get; init; }
        public string ReciverName { get; init; }
        public string? Message { get; init; }
        public string PhoneNumber { get; init; }
    }
}