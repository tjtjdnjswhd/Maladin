using Microsoft.EntityFrameworkCore;

using Maladin.Data.Enums;
using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// <paramref name="order"/>를 검증 후 저장된 <see cref="Order"/>를 반환합니다
        /// </summary>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult<Order?>> TryAddOrderAsync(OrderContext order, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/> 개체를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<Order?>> GetOrderOrNullAsync(int orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <paramref name="searchContext"/>에 해당하는 <see cref="Order"/> 개체들을 반환합니다
        /// </summary>
        /// <param name="searchContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<IEnumerable<Order>>> GetOrdersAsync(OrderSearchContext searchContext, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>와 결제 정보를 검증 후 저장된 결제 정보를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="impUid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult<IamportPayment?>> TryAddPaymentAsync(int orderId, string impUid, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>를 모두 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> RefundAllAsync(int orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>의 일부를 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="refundQtyByBookId"></param>
        /// <param name="isPointFirstRefund"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> RefundPartialAsync(int orderId, Dictionary<int, int> refundQtyByBookId, bool isPointFirstRefund, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order.Message"/>를 변경합니다.
        /// 해당 <see cref="Order.State"/> 값이 <see cref="EOrderState.Delivering"/>, <see cref="EOrderState.DeliveryComplete"/>일 경우 변경 불가능합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> UpdateMessageAsync(int orderId, string? message, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order.Address"/>를 변경합니다.
        /// 해당 <see cref="Order.State"/> 값이 <see cref="EOrderState.Delivering"/>, <see cref="EOrderState.DeliveryComplete"/>일 경우 변경 불가능합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="address"></param>
        /// <param name="postCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> UpdateAddressAsync(int orderId, string address, string postCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order.State"/>를 변경합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderState"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> UpdateOrderStateAsync(int orderId, EOrderState orderState, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order.DeliveryId"/>, <see cref="Order.InvoiceNumber"/>를 변경합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deliveryId"></param>
        /// <param name="invoiceMember"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> SetDeliveryAsync(int orderId, int deliveryId, string invoiceMember, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order.DeliveryId"/>, <see cref="Order.InvoiceNumber"/>를 삭제합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> ResetDeliveryAsync(int orderId, CancellationToken cancellationToken = default);
    }
}