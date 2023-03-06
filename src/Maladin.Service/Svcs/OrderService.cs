using ExceptionLogger;

using Maladin.Data;
using Maladin.Data.Enums;
using Maladin.Data.Models;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Linq.Expressions;

namespace Maladin.Service.Svcs
{
    public class OrderService : IOrderService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly ILogger<OrderService> _logger;
        private readonly IExceptionLogger<OrderService> _exceptionLogger;

        public OrderService(MaladinDbContext dbContext, ILogger<OrderService> logger, IExceptionLogger<OrderService> exceptionLogger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _exceptionLogger = exceptionLogger;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<Order?>> TryAddOrderAsync(OrderContext order, CancellationToken cancellationToken = default)
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

            int totalPrice = priceByBookId.Sum(b => b.Value * order.QtyByBookId.GetValueOrDefault(b.Key));

            using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            if (order.PointAmount > 0)
            {
                if (order.PointAmount > totalPrice)
                {
                    return new ServiceResult<Order?>(null, EErrorCode.PointOverTotalPrice);
                }

                if (!_dbContext.TryConsumePoint(order.UserId, order.PointAmount))
                {
                    return new ServiceResult<Order?>(null, EErrorCode.NotEnoughPoint);
                }
            }

            Order result = new()
            {
                UserId = order.UserId,
                UsedPoint = order.PointAmount,
                OrderedAt = DateTimeOffset.UtcNow,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Postcode = order.PostCode,
                ReceiverName = order.ReciverName,
                State = EOrderState.BeforeReady
            };

            _dbContext.Add(result);
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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
            Expression<Func<Order, bool>> stateFilter = order => order.State == searchContext.DeliveryStateOrNull.GetValueOrDefault(order.State);
            Expression<Func<Order, bool>> dateFilter = order => order.OrderedAt > searchContext.Start && order.OrderedAt < searchContext.End;
            Expression<Func<Order, bool>> amountFilter = order => order.OrderBooks.Sum(orderBook => orderBook.OrderQty * orderBook.PricePerItem) < searchContext.MaxAmount && order.OrderBooks.Sum(orderBook => orderBook.OrderQty * orderBook.PricePerItem) > searchContext.MinAmount;
            Expression<Func<Order, bool>> textFilter = order => true;

            switch (searchContext.FilterTarget)
            {
                case EOrderSearchTarget.BookTitle:
                    textFilter = order => order.OrderBooks.Any(orderBook => EF.Functions.Like(orderBook.Book.BookDisplay.Title, searchContext.TextFilter.ToString()));
                    break;
                case EOrderSearchTarget.ReceiverName:
                    textFilter = order => EF.Functions.Like(order.ReceiverName, searchContext.TextFilter.ToString());
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

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdateMessageAsync(int orderId, string? message, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
            }

            order.Message = message;
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdateAddressAsync(int orderId, string address, string postCode, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
            }

            order.Address = address;
            order.Postcode = postCode;
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdateOrderStateAsync(int orderId, EOrderState orderState, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
            }

            order.State = orderState;
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> SetDeliveryAsync(int orderId, int deliveryId, string invoiceMember, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
            }

            order.DeliveryId = deliveryId;
            order.InvoiceNumber = invoiceMember;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> ResetDeliveryAsync(int orderId, CancellationToken cancellationToken = default)
        {
            Order? order;
            try
            {
                order = await _dbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            if (order == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(orderId));
            }

            order.DeliveryId = null;
            order.InvoiceNumber = null;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Assert(e is OperationCanceledException or DbUpdateException, "Unexpected exception");
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }
    }
}