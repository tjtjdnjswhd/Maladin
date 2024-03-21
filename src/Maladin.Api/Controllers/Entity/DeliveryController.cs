using AutoMapper;

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
    public class DeliveryController(MaladinDbContext dbContext, IMapper mapper, ILogger<DeliveryController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}