using Maladin.Api.Models;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TossPayments.Core.Client;
using TossPayments.Core.Response;

namespace Maladin.Api.Controllers.Entity
{
    [ApiController]
    [Route("api/payment/tosspayments")]
    public class TossPaymentsController(MaladinDbContext dbContext, ILogger<TossPaymentsController> logger, ITossPaymentsCoreClient tossPaymentsCoreClient, IPaymentService paymentService) : ControllerBase
    {
        private readonly MaladinDbContext _dbContext = dbContext;
        private readonly ILogger<TossPaymentsController> _logger = logger;
        private readonly ITossPaymentsCoreClient _tossPaymentsCoreClient = tossPaymentsCoreClient;
        private readonly IPaymentService _paymentService = paymentService;

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAsync([FromForm] string paymentKey, [FromForm] Guid orderId, [FromForm] int amount, CancellationToken cancellationToken)
        {
            PaymentPrepareResponse? prepare = await _paymentService.GetCachedPrepareAsync(orderId, cancellationToken);
            if (prepare is null)
            {
                return NotFound();
            }

            if (prepare.Amount != amount)
            {
                return BadRequest();
            }

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            TossPaymentsPayment payment = new(paymentKey, amount);
            Payment? confirmResult = await strategy.ExecuteAsync(_dbContext, async (dbContext, token) => await ConfirmPaymentAsync(dbContext, payment, prepare, token), cancellationToken);
            if (confirmResult is null)
            {
                return BadRequest("Not enough point");
            }

            if (confirmResult.Failure is not null)
            {
                return BadRequest(confirmResult.Failure.Message);
            }

            return Ok(confirmResult);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelAsync([FromForm] string paymentKey, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TossPayments payment cancelled. PaymentKey: {PaymentKey}", paymentKey);
            await _tossPaymentsCoreClient.CancelPaymentAsync(paymentKey, new TossPayments.Core.Request.CancelRequest() { CancelReason = "User cancel", Currency = "KRW" }, cancellationToken: cancellationToken);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="payment"></param>
        /// <param name="prepare"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>null if point is not enough</returns>
        private async Task<Payment?> ConfirmPaymentAsync(MaladinDbContext dbContext, TossPaymentsPayment payment, PaymentPrepareResponse prepare, CancellationToken cancellationToken = default)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            if (prepare.Point > 0 && !await dbContext.TryConsumePointAsync(prepare.UserId, prepare.Point, cancellationToken))
            {
                _logger.LogInformation("Point not enough. UserId: {UserId}", prepare.UserId);
                return null;
            }

            Payment tossPayment;
            try
            {
                dbContext.TossPaymentsPayments.Add(payment);
                dbContext.SaveChanges();
                tossPayment = await _tossPaymentsCoreClient.ConfirmPaymentAsync(payment.PaymentKey, prepare.OrderUid.ToString(), prepare.Amount, cancellationToken);
                transaction.Commit();
                _logger.LogInformation("TossPayments confirmed. PaymentKey: {PaymentKey}", payment.PaymentKey);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Payment DB transaction failed");
                await _tossPaymentsCoreClient.CancelPaymentAsync(payment.PaymentKey, new TossPayments.Core.Request.CancelRequest() { CancelReason = "Server error", Currency = "KRW" }, cancellationToken: CancellationToken.None);
                throw;
            }
            return tossPayment;
        }
    }
}