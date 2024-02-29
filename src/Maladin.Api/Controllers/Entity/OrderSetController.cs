using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class OrderSetController(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OrderSet, OrderSetRead, OrderSetCreate, OrderSetUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}