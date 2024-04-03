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
    public class DeliveryController(MaladinDbContext dbContext, ILogger<DeliveryController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>> actionFilterOptions)
        : EntityControllerBase<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}