using Maladin.Data.Enums;
using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// 신규 <see cref="Order"/> 개체를 추가합니다
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Task<ServiceResult<Order>> AddOrderAsync(OrderContext order);

        /// <summary>
        /// 해당 <see cref="Order"/> 개체를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<ServiceResult<Order>> GetOrderAsync(int orderId);

        /// <summary>
        /// <paramref name="searchContext"/>에 해당하는 <see cref="Order"/> 개체들을 반환합니다
        /// </summary>
        /// <param name="searchContext"></param>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<Order>>> GetOrdersAsync(OrderSearchContext searchContext);

        /// <summary>
        /// 해당 <see cref="Order.Message"/>를 변경합니다.
        /// 해당 <see cref="Order.State"/> 값이 <see cref="EOrderState.Delivering"/>, <see cref="EOrderState.DeliveryComplete"/>일 경우 변경 불가능합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateMessageAsync(int orderId, string? message);

        /// <summary>
        /// 해당 <see cref="Order.Address"/>를 변경합니다.
        /// 해당 <see cref="Order.State"/> 값이 <see cref="EOrderState.Delivering"/>, <see cref="EOrderState.DeliveryComplete"/>일 경우 변경 불가능합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="address"></param>
        /// <param name="postCode"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateAddressAsync(int orderId, string address, string postCode);

        /// <summary>
        /// 해당 <see cref="Order.State"/>를 변경합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateOrderStateAsync(int orderId, EOrderState orderState);

        /// <summary>
        /// 해당 <see cref="Order.DeliveryId"/>, <see cref="Order.InvoiceNumber"/>를 변경합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deliveryId"></param>
        /// <param name="invoiceMember"></param>
        /// <returns></returns>
        public Task<ServiceResult> SetDeliveryAsync(int orderId, int deliveryId, string invoiceMember);

        /// <summary>
        /// 해당 <see cref="Order.DeliveryId"/>, <see cref="Order.InvoiceNumber"/>를 삭제합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<ServiceResult> ResetDeliveryAsync(int orderId);
    }
}