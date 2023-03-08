using Maladin.Data.Enums;

namespace Maladin.Service.Models
{
    public class OrderUpdateContext
    {
        /// <exception cref="ArgumentException"><paramref name="newAddress"/>, <paramref name="newPostcode"/> 둘 중 하나만 설정될 시</exception>
        public OrderUpdateContext(int orderId, string? newMessage, string? newAddress, string? newPostcode, EOrderState? newOrderState)
        {
            OrderId = orderId;
            NewMessage = newMessage;
            NewAddress = newAddress;
            NewPostcode = newPostcode;
            NewOrderState = newOrderState;
        }

        public int OrderId { get; init; }
        public string? NewMessage { get; init; }
        public string? NewAddress { get; init; }
        public string? NewPostcode { get; set; }
        public EOrderState? NewOrderState { get; init; }
    }
}