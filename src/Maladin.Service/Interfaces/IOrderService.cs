using Microsoft.EntityFrameworkCore;

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
        public Task<ServiceResult<Order?>> TryAddOrderAsync(OrderAddContext order, CancellationToken cancellationToken = default);

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
        /// <returns></returns>
        public ServiceResult<IAsyncEnumerable<Order>> GetOrders(OrderSearchContext searchContext);

        public Task<ServiceResult<Order?>> UpdateAsync(OrderUpdateContext updateContext, CancellationToken cancellationToken = default);

        public Task<ServiceResult<Order?>> SyncPayment(int orderId, string paymentId, CancellationToken cancellationToken = default);

        public Task<ServiceResult<bool>> TryCancelAsync(int orderId, Dictionary<int, int> cancelQtyByBookId, VirtualBankRefundInfo? vBankRefundInfo = null, CancellationToken cancellationToken = default);
    }
}