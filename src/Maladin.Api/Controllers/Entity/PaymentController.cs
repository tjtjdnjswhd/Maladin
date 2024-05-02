using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System.Diagnostics;

namespace Maladin.Api.Controllers.Entity
{
    public class PaymentController(MaladinDbContext dbContext, ILogger logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>> actionFilterOptions, IPaymentService paymentService)
        : EntityControllerBase<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(dbContext, logger, entityConfiguration, crudOptions, actionFilterOptions)
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpPost("prepare")]
        [UserAuthorize]
        public async Task<IActionResult> PrepareAsync(PaymentPrepareRequest prepareRequest, CancellationToken cancellationToken)
        {
            var priceByGoodsId = await DbContext.Goods
                .Where(g => prepareRequest.OrderQtyByGoodsId.Keys.Contains(g.Id))
                .Select(g => new { g.Id, g.Price })
                .ToListAsync(cancellationToken);

            if (priceByGoodsId.Count != prepareRequest.OrderQtyByGoodsId.Count)
            {
                return NotFound();
            }

            bool canGetUserId = HttpContext.TryGetUserId(out int userId);
            Debug.Assert(canGetUserId);
            int amount = priceByGoodsId.Sum(g => prepareRequest.OrderQtyByGoodsId[g.Id] * g.Price) - prepareRequest.Point;
            PaymentPrepareResponse response = await _paymentService.PrepareAsync(userId, amount, prepareRequest.Point, cancellationToken);
            return Ok(response);
        }

        [NonAction]
        public override Task<IActionResult> PostAsync([FromBody] PaymentCreate dto, CancellationToken cancellationToken)
        {
            return base.PostAsync(dto, cancellationToken);
        }

        [NonAction]
        public override Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] PaymentUpdate dto, CancellationToken cancellationToken)
        {
            return base.PutAsync(id, dto, cancellationToken);
        }

        [NonAction]
        public override Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            return base.DeleteAsync(id, cancellationToken);
        }
    }
}