using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.Extensions.Options;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsController(MaladinDbContext dbContext, ILogger<GoodsController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>> actionFilterOptions)
        : EntityControllerBase<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}