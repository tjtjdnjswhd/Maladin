using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class DeliveryController(MaladinDbContext dbContext, IMapper mapper, ILogger<DeliveryController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Delivery, DeliveryRead, DeliveryCreate, DeliveryUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}