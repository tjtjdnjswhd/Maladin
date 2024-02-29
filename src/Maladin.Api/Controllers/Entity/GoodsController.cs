using AutoMapper;

using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}