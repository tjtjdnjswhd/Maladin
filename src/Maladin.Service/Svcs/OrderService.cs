using Maladin.Data;
using Maladin.Data.Enums;
using Maladin.Data.Models;
using Maladin.Service.Extensions;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

using Utils;

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
            var orderedBooks = _dbContext.Books.Where(b => order.QtyByBookId.Keys.Contains(b.Id));
            if (orderedBooks.Count() != order.QtyByBookId.Count)
            {
                return new ServiceResult<Order?>(null, EErrorCode.NotExist, nameof(order.QtyByBookId));
            }

            int totalAmount = orderedBooks.Sum(b => b.Price);
            if (totalAmount < order.PointAmount)
            {
                return new ServiceResult<Order?>(null, EErrorCode.PointOverAmount);
            }

            using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            bool isPointConsumed = _dbContext.ConsumePoint(order.UserId, order.PointAmount);
            if (!isPointConsumed)
            {
                return new ServiceResult<Order?>(null, EErrorCode.NotEnoughPoint);
            }

            Order result = new()
            {
                UserId = order.UserId,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Postcode = order.PostCode,
                ReceiverName = order.ReciverName,
                OrderedAt = DateTimeOffset.UtcNow,
                State = EOrderState.BeforeReady
            };

            _dbContext.Orders.Add(result);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            var orderList = order.QtyByBookId.Select(bb => new OrderBook()
            {
                BookId = bb.Key,
                OrderId = result.Id,
                OrderQty = bb.Value,
                PricePerItem = orderedBooks.First(b => b.Id == bb.Key).Price
            });

            _dbContext.OrderBooks.AddRange(orderList);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
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
        public Task<ServiceResult<IEnumerable<Order>>> GetOrdersAsync(OrderSearchContext searchContext, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult<IamportPayment?>> TryAddPaymentAsync(int orderId, string impUid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> RefundAllAsync(int orderId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> RefundPartialAsync(int orderId, Dictionary<int, int> refundQtyByBookId, bool isPointFirstRefund, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdateMessageAsync(int orderId, string? message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdateAddressAsync(int orderId, string address, string postCode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdateOrderStateAsync(int orderId, EOrderState orderState, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> SetDeliveryAsync(int orderId, int deliveryId, string invoiceMember, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> ResetDeliveryAsync(int orderId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}