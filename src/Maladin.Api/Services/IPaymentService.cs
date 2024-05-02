using Maladin.Api.Models;

namespace Maladin.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentPrepareResponse> GetCachedPrepareAsync(Guid orderUid, CancellationToken cancellationToken = default);
        Task<PaymentPrepareResponse> PrepareAsync(int userId, int amount, int point, CancellationToken cancellationToken = default);
    }
}