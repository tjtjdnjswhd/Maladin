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
    public class GoodsCategoryController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsCategoryController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>> crudOptions, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}