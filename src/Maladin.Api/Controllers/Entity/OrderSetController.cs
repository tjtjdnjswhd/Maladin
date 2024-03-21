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
    public class OrderSetController(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IEntityConfigurationService configuration, IOptions<CrudOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}