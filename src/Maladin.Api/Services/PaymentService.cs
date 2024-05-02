using Maladin.Api.Models;

using Microsoft.Extensions.Caching.Distributed;

using System.Diagnostics;
using System.Text.Json;

namespace Maladin.Api.Services
{
    public class PaymentService(IDistributedCache cache) : IPaymentService
    {
        private const string CachePrefix = "__Payment_";

        private readonly IDistributedCache _cache = cache;

        public async Task<PaymentPrepareResponse> PrepareAsync(int userId, int amount, int point, CancellationToken cancellationToken = default)
        {
            Guid orderUid = Guid.NewGuid();
            PaymentPrepareResponse response = new(userId, orderUid, amount, point);
            await _cache.SetAsync(GetCacheKey(orderUid), JsonSerializer.SerializeToUtf8Bytes(response), cancellationToken);
            return response;
        }

        public async Task<PaymentPrepareResponse> GetCachedPrepareAsync(Guid orderUid, CancellationToken cancellationToken = default)
        {
            byte[] cached = await _cache.GetAsync(GetCacheKey(orderUid), cancellationToken) ?? throw new KeyNotFoundException();
            PaymentPrepareResponse? cachedResponse = JsonSerializer.Deserialize<PaymentPrepareResponse>(cached);
            Debug.Assert(cachedResponse is not null);

            return cachedResponse;
        }

        private static string GetCacheKey(Guid orderId) => $"{CachePrefix}{orderId}";
    }
}