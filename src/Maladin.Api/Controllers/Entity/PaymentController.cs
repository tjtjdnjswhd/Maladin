using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;

using Microsoft.Extensions.Options;

namespace Maladin.Api.Controllers.Entity
{
    public class PaymentController(MaladinDbContext dbContext, ILogger<PaymentController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>> crudOptions, IOptions<Options.EntityActionFilterOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>> actionFilterOptions)
        : EntityControllerBase<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}