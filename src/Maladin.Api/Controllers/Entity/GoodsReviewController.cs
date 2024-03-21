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
    public class GoodsReviewController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsReviewController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}