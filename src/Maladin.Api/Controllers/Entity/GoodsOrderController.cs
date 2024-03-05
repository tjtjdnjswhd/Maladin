using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsOrderController(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}