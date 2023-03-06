using Microsoft.EntityFrameworkCore;

using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IPortonePaymentService
    {
        /// <summary>
        /// 해당 <see cref="Order"/>의 결제 금액을 검증합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="impUid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<bool>> VerifyAmountAsync(int orderId, string impUid, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>의 금액과 결제 정보를 검증 후 저장한 결제 정보를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="impUid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult<PortonePayment?>> TryAddPayment(int orderId, string impUid, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>의 결제 정보를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<PortonePayment?>> GetPaymentByOrderIdOrNullAsync(int orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>의 상세 결제 정보를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<PortonePaymentResponse?>> GetResponseByOrderIdOrNullAsync(int orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>를 모두 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> CancelAllAsync(int orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 <see cref="Order"/>의 일부를 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="refundQtyByBookId"></param>
        /// <param name="isRefundPoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> CancelPartialAsync(int orderId, Dictionary<int, int> refundQtyByBookId, bool isRefundPoint, CancellationToken cancellationToken = default);
    }
}
