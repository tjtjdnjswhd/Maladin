using ExceptionLogger;

using Maladin.Data;
using Maladin.Data.Models;
using Maladin.Service.Constants;
using Maladin.Service.Extensions;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;
using Maladin.Service.Settings;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Maladin.Service.Svcs
{
    public class PortonePaymentService : IPortonePaymentService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly IDistributedCache _cache;
        private readonly ILogger<PortonePaymentService> _logger;
        private readonly IExceptionLogger<PortonePayment> _exceptionLogger;
        private readonly PortonePaymentServiceSettings _settings;

        public PortonePaymentService(MaladinDbContext dbContext, IDistributedCache cache, ILogger<PortonePaymentService> logger, IExceptionLogger<PortonePayment> exceptionLogger, IOptions<PortonePaymentServiceSettings> settings)
        {
            _dbContext = dbContext;
            _cache = cache;
            _logger = logger;
            _exceptionLogger = exceptionLogger;
            _settings = settings.Value;
        }

        public async Task<ServiceResult<bool>> VerifyAmountAsync(int orderId, string impUid, CancellationToken cancellationToken = default)
        {
            PortonePaymentResponse? info;
            try
            {
                info = await GetPaymentResponseOrNullAsync(impUid, cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (info == null)
            {
                return new ServiceResult<bool>(false, EErrorCode.FailGetPortoneAccessToken);
            }

            int orderTotalAmount = _dbContext.GetOrderTotalAmount(orderId);

            return new ServiceResult<bool>(info.Amount == orderTotalAmount, EErrorCode.NoError);
        }

        public async Task<ServiceResult<PortonePayment?>> TryAddPayment(int orderId, string impUid, CancellationToken cancellationToken = default)
        {
            PortonePaymentResponse? info;
            try
            {
                info = await GetPaymentResponseOrNullAsync(impUid, cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (info == null)
            {
                return new ServiceResult<PortonePayment?>(null, EErrorCode.FailGetPortoneAccessToken);
            }

            int orderTotalAmount = _dbContext.GetOrderTotalAmount(orderId);
            if (orderTotalAmount != info.Amount)
            {
                return new ServiceResult<PortonePayment?>(null, EErrorCode.InvalidPayment);
            }

            PortonePayment portonePayment = new()
            {
                OrderId = orderId,
                ImpUid = impUid,
                Amount = info.Amount,
            };

            _dbContext.PortonePayments.Add(portonePayment);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException);
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult<PortonePayment?>.NoError(portonePayment);
        }

        public async Task<ServiceResult<PortonePayment?>> GetPaymentByOrderIdOrNullAsync(int orderId, CancellationToken cancellationToken = default)
        {
            PortonePayment? result;
            try
            {
                result = await _dbContext.PortonePayments.FirstOrDefaultAsync(p => p.OrderId == orderId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return new ServiceResult<PortonePayment?>(result, result == null ? EErrorCode.NotExist : EErrorCode.NoError);
        }

        public async Task<ServiceResult<PortonePaymentResponse?>> GetResponseByOrderIdOrNullAsync(int orderId, CancellationToken cancellationToken = default)
        {
            string? impUid;
            PortonePaymentResponse? result;
            try
            {
                impUid = await _dbContext.PortonePayments.Where(p => p.OrderId == orderId).Select(p => p.ImpUid).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                if (impUid == null)
                {
                    return new ServiceResult<PortonePaymentResponse?>(null, EErrorCode.NotExist, nameof(orderId));
                }

                result = await GetPaymentResponseOrNullAsync(impUid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return new ServiceResult<PortonePaymentResponse?>(result, result == null ? EErrorCode.NotExist : EErrorCode.NoError);
        }

        public async Task<ServiceResult> CancelAllAsync(int orderId, CancellationToken cancellationToken = default)
        {
            string? impUid;
            Order? order;
            PortonePaymentResponse? info;

            try
            {
                order = await _dbContext.FindAsync<Order>(new object[] { orderId }, cancellationToken).ConfigureAwait(false);
                if (order == null)
                {
                    return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
                }

                impUid = await _dbContext.PortonePayments.Where(p => p.OrderId == orderId).Select(p => p.ImpUid).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

                if (impUid == null)
                {
                    return new ServiceResult(EErrorCode.NotExist, nameof(PortonePayment));
                }

                info = await GetPaymentResponseOrNullAsync(impUid, cancellationToken).ConfigureAwait(false);

                if (info == null)
                {
                    return new ServiceResult(EErrorCode.NotExist, nameof(impUid));
                }
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            _dbContext.Entry(order).Collection(o => o.OrderBooks).Load();

            throw new Exception();
        }

        public Task<ServiceResult> CancelPartialAsync(int orderId, Dictionary<int, int> refundQtyByBookId, bool isRefundPoint, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private async Task<PortonePaymentResponse?> GetPaymentResponseOrNullAsync(string impUid, CancellationToken cancellationToken)
        {
            using HttpClient httpClient = await GetPortoneClientAsync(true, cancellationToken);

            PortonePaymentResponse detail;
            try
            {
                detail = (await httpClient.GetFromJsonAsync<PortonePaymentResponse>($"{_settings.PaymentUrl}/{impUid}", cancellationToken).ConfigureAwait(false))!;
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return detail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impUid"></param>
        /// <param name="orderId"></param>
        /// <param name="cancelAmount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        private async Task<bool> TryCancelAsync(string impUid, int orderId, int cancelAmount, CancellationToken cancellationToken = default)
        {
            using HttpClient httpClient = await GetPortoneClientAsync(true, cancellationToken);

            int currentAmount = _dbContext.GetOrderCurrentAmount(orderId);

            PortoneCancelRequest cancelRequest = new()
            {
                ImpUid = impUid,
                MerchantUid = orderId.ToString(),
                Amount = cancelAmount,
                Checksum = currentAmount
            };

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(_settings.CancelUrl, cancelRequest, cancellationToken);
            response.EnsureSuccessStatusCode();

            PortonePaymentResponse paymentResponse = (await response.Content.ReadFromJsonAsync<PortonePaymentResponse>(cancellationToken: cancellationToken))!;

            throw new Exception();
        }

        /// <summary>
        /// Portone과 연결된 <see cref="HttpClient"/>를 반환합니다
        /// </summary>
        /// <param name="setAccessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        private async Task<HttpClient> GetPortoneClientAsync(bool setAccessToken, CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = new()
            {
                BaseAddress = new(_settings.BaseUrl)
            };

            if (!setAccessToken)
            {
                return httpClient;
            }

            string? cachedToken = _cache.GetString(PortoneConstants.ACCESS_TOKEN_CACHE_KEY);
            if (cachedToken != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new("Bearer", cachedToken);
                return httpClient;
            }

            PortoneAccessTokenRequest request = new(_settings.ApiKey, _settings.ApiSecret);
            using HttpResponseMessage response = await httpClient.PostAsJsonAsync(_settings.AccessTokenGetUrl, request, cancellationToken);
            response.EnsureSuccessStatusCode();

            string responseText = await response.Content.ReadAsStringAsync(cancellationToken);
            using JsonDocument jsonDocument = JsonDocument.Parse(responseText);
            string accessToken = jsonDocument.RootElement.GetProperty("response").GetProperty("access_token").GetString()!;
            long expiredAtUnix = jsonDocument.RootElement.GetProperty("response").GetProperty("expired_at").GetInt64();

            _cache.SetString(PortoneConstants.ACCESS_TOKEN_CACHE_KEY, accessToken, new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.FromUnixTimeSeconds(expiredAtUnix)
            });

            httpClient.DefaultRequestHeaders.Authorization = new("Bearer", accessToken);
            return httpClient;
        }
    }
}
