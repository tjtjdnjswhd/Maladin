using Maladin.Api.Models;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using TossPayments.Core.Client;
using TossPayments.Core.Response;
using TossPayments.WebHookBody;

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
            Payment? tossPayment = await strategy.ExecuteAsync(_dbContext, async (dbContext, token) => await ConfirmPaymentAsync(dbContext, payment, prepare, token), cancellationToken);

            return tossPayment is not null ? Ok(tossPayment) : BadRequest();
        }

        [HttpPost("virtualaccount-callback")]
        public async Task VirtualAccountCallback([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] DespositCallback callback)
        {
        }

        private async Task<Payment?> ConfirmPaymentAsync(MaladinDbContext dbContext, TossPaymentsPayment payment, PaymentPrepareResponse prepare, CancellationToken cancellationToken = default)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            if (prepare.Point > 0 && !await dbContext.TryConsumePointAsync(prepare.UserId, prepare.Point, cancellationToken))
            {
                return null;
            }

            dbContext.TossPaymentsPayments.Add(payment);
            dbContext.SaveChanges();
            Payment tossPayment = await _tossPaymentsCoreClient.ConfirmPaymentAsync(payment.PaymentKey, prepare.OrderUid.ToString(), prepare.Amount, cancellationToken);
            transaction.Commit();
            return tossPayment;
        }
    }
}