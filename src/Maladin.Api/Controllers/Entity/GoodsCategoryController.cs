using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsCategoryController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsCategoryController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsCategory, GoodsCategoryRead, GoodsCategoryCreate, GoodsCategoryUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}