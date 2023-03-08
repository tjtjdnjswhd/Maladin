using ExceptionLogger;

using Maladin.Data;
using Maladin.Data.Enums;
using Maladin.Data.Models;
using Maladin.Service.Constants;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;
using Maladin.Service.Models.Internals;
using Maladin.Service.Settings;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;

namespace Maladin.Service.Svcs
{
    public class OrderService : IOrderService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly IDistributedCache _cache;
        private readonly ILogger<OrderService> _logger;
        private readonly IExceptionLogger<OrderService> _exceptionLogger;
        private readonly PortonePaymentSettings _paymentSettings;

        public OrderService(MaladinDbContext dbContext, IDistributedCache cache, ILogger<OrderService> logger, IExceptionLogger<OrderService> exceptionLogger, IOptions<PortonePaymentSettings> paymentSettings)
        {
            _dbContext = dbContext;
            _cache = cache;
            _logger = logger;
            _exceptionLogger = exceptionLogger;
            _paymentSettings = paymentSettings.Value;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<Order?>> TryAddOrderAsync(OrderAddContext order, CancellationToken cancellationToken = default)
        {
            Dictionary<int, int> priceByBookId;
            try
            {
                priceByBookId = await _dbContext.Books.Where(b => order.QtyByBookId.Keys.Contains(b.Id))
                                            .ToDictionaryAsync(b => b.Id, b => b.Price, cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (priceByBookId.Count != order.QtyByBookId.Count)
            {
                return new ServiceResult<Order?>(null, EErrorCode.NotExist, nameof(order.QtyByBookId));
            }

            int amountTotal = priceByBookId.Sum(b => b.Value * order.QtyByBookId.GetValueOrDefault(b.Key));

            using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            if (order.AmountPoint > 0)
            {
                if (order.AmountPoint > amountTotal)
                {
                    return new ServiceResult<Order?>(null, EErrorCode.PointOverAmount);
                }

                if (!_dbContext.TryConsumePoint(order.UserId, order.AmountPoint))
                {
                    return new ServiceResult<Order?>(null, EErrorCode.NotEnoughPoint);
                }
            }

            int paymentAmount = amountTotal - order.AmountPoint;

            Order result = new()
            {
                UserId = order.UserId,
                UsedPoint = order.AmountPoint,
                OrderedAt = DateTimeOffset.UtcNow,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Postcode = order.PostCode,
                ReceiverName = order.ReciverName,
                OrderState = EOrderState.BeforeReady,
                OrderBooks = order.QtyByBookId.Select(qb => new OrderBook()
                {
                    BookId = qb.Key,
                    CancelQty = 0,
                    OrderQty = qb.Value,
                    PricePerItem = priceByBookId[qb.Key]
                }).ToList(),
                Payment = new()
                {
                    Amount = paymentAmount,
                    CancelledAmount = 0,
                    State = EPaymentState.Prepare
                }
            };

            _dbContext.Add(result);
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await PreparePaymentAsync(result.Id, paymentAmount, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            transaction.Commit();
            return ServiceResult<Order?>.NoError(result);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<Order?>> GetOrderOrNullAsync(int orderId, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.FindAsync<Order>(new object[] { orderId }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult<Order?>(null, EErrorCode.NotExist, nameof(orderId));
            }

            return ServiceResult<Order?>.NoError(order);
        }

        /// <inheritdoc/>
        public ServiceResult<IAsyncEnumerable<Order>> GetOrders(OrderSearchContext searchContext)
        {
            Expression<Func<Order, bool>> userIdFilter = order => order.UserId == searchContext.UserIdOrNull.GetValueOrDefault(order.UserId);
            Expression<Func<Order, bool>> stateFilter = order => order.OrderState == searchContext.DeliveryStateOrNull.GetValueOrDefault(order.OrderState);
            Expression<Func<Order, bool>> dateFilter = order => order.OrderedAt > searchContext.Start && order.OrderedAt < searchContext.End;
            Expression<Func<Order, bool>> amountFilter = order => order.OrderBooks.Sum(orderBook => orderBook.OrderQty * orderBook.PricePerItem) < searchContext.MaxAmount && order.OrderBooks.Sum(orderBook => orderBook.OrderQty * orderBook.PricePerItem) > searchContext.MinAmount;
            Expression<Func<Order, bool>> textFilter = order => 1 == 1;

            switch (searchContext.SearchTarget)
            {
                case EOrderSearchTarget.BookTitle:
                    textFilter = order => order.OrderBooks.Any(orderBook => EF.Functions.Like(orderBook.Book.BookDisplay.Title, searchContext.TargetFilter.ToString()));
                    break;
                case EOrderSearchTarget.ReceiverName:
                    textFilter = order => EF.Functions.Like(order.ReceiverName, searchContext.TargetFilter.ToString());
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            var result = _dbContext.Orders
                            .Where(userIdFilter)
                            .Where(stateFilter)
                            .Where(dateFilter)
                            .Where(textFilter)
                            .Skip(searchContext.Skip)
                            .Take(searchContext.Take).AsNoTracking().AsAsyncEnumerable();

            return ServiceResult<IAsyncEnumerable<Order>>.NoError(result);
        }

        public async Task<ServiceResult<Order?>> UpdateOrderAsync(OrderUpdateContext updateContext, CancellationToken cancellationToken = default)
        {
            if (updateContext.NewAddress == null ^ updateContext.NewPostcode == null)
            {
                throw new ArgumentException($"{nameof(updateContext.NewAddress)}와 {nameof(updateContext.NewPostcode)}는 동시에 설정되야 합니다");
            }

            Order? order;
            try
            {
                order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == updateContext.OrderId, cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException);
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult<Order?>(null, EErrorCode.NotExist, nameof(updateContext.OrderId));
            }

            if (updateContext.NewMessage != null)
            {
                order.Message = updateContext.NewMessage;
            }

            if (updateContext.NewAddress != null)
            {
                order.Address = updateContext.NewAddress;
                order.Postcode = updateContext.NewPostcode;
            }

            if (updateContext.NewOrderState != null)
            {
                order.OrderState = updateContext.NewOrderState.Value;
            }

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return new ServiceResult<Order?>(order, EErrorCode.NoError);
        }

        public async Task<ServiceResult<Order?>> SyncOrderPayment(int orderId, string paymentId, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.Include(o => o.Payment).FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

                if (order == null)
                {
                    return new ServiceResult<Order?>(null, EErrorCode.NotExist, nameof(orderId));
                }

                using HttpClient portoneClient = await GetPortoneClientAsync(true, cancellationToken);
                PortonePaymentResponse paymentResponse = (await portoneClient.GetFromJsonAsync<PortonePaymentResponse>(_paymentSettings.PaymentUrl, cancellationToken))!;

                if (!int.TryParse(paymentResponse.MerchantUid, out int id) || id != orderId)
                {
                    return new ServiceResult<Order?>(null, EErrorCode.InvalidPayment, nameof(paymentId));
                }

                order.Payment.Amount = paymentResponse.Amount;
                order.Payment.CancelledAmount = paymentResponse.CancelAmount;
                order.Payment.ImpUid = paymentResponse.ImpUid;

                if (paymentResponse.Status == PortonePaymentResponse.EStatus.Paid)
                {
                    order.Payment.State = EPaymentState.Paid;
                }
                else if (paymentResponse.Status == PortonePaymentResponse.EStatus.Ready)
                {
                    order.Payment.State = EPaymentState.Ready;
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException);
                _exceptionLogger.Log(e);
                throw;
            }

            return new ServiceResult<Order?>(order, EErrorCode.NoError);
        }

        public async Task<ServiceResult<bool>> TryCancelAsync(int orderId, Dictionary<int, int> cancelQtyByBookId, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.Include(o => o.OrderBooks).FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexcepted exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult<bool>(false, EErrorCode.NotExist, nameof(orderId));
            }

            Dictionary<int, int> qtyByBookId = order.OrderBooks.ToDictionary(ob => ob.BookId, ob => ob.OrderQty - ob.CancelQty);

            throw new NotImplementedException();
        }

        private async Task PreparePaymentAsync(int orderId, int amountTotal, CancellationToken cancellationToken = default)
        {
            using HttpClient portoneClient = await GetPortoneClientAsync(true, cancellationToken);
            PortonePrepareRequest prepareRequest = new(orderId.ToString(), amountTotal);
            using HttpResponseMessage response = await portoneClient.PostAsJsonAsync(_paymentSettings.PrepareUrl, prepareRequest, cancellationToken);
            response.EnsureSuccessStatusCode();
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
                BaseAddress = new(_paymentSettings.BaseUrl)
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

            PortoneAccessTokenRequest request = new(_paymentSettings.ApiKey, _paymentSettings.ApiSecret);
            using HttpResponseMessage response = await httpClient.PostAsJsonAsync(_paymentSettings.AccessTokenUrl, request, cancellationToken);
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