using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// 해당 <see cref="Order"/>와 결제 정보를 검증 후 해당 결제 정보를 반환합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="impUid"></param>
        /// <returns></returns>
        public Task<ServiceResult<IamportPayment>> PayAsync(int orderId, string impUid);

        /// <summary>
        /// 해당 <see cref="Order"/>를 모두 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RefundAllAsync(int orderId);

        /// <summary>
        /// 해당 <see cref="Order"/>의 일부를 환불합니다
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="refundQtyByBook"></param>
        /// <param name="isPointFirstRefund"></param>
        /// <returns></returns>
        public Task<ServiceResult> RefundPartialAsync(int orderId, Dictionary<Book, int> refundQtyByBook, bool isPointFirstRefund);
    }
}