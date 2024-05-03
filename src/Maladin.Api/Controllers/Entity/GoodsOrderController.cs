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
    public class GoodsOrderController(MaladinDbContext dbContext, ILogger<GoodsOrderController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>> crudOptions, Microsoft.Extensions.Options.IOptions<Options.EntityActionFilterOptions<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>> actionFilterOptions)
        : EntityControllerBase<GoodsOrder, GoodsOrderRead, GoodsOrderCreate, GoodsOrderUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}