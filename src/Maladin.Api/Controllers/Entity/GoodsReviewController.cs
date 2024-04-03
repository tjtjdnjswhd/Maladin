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
    public class GoodsReviewController(MaladinDbContext dbContext, ILogger<GoodsReviewController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>> crudOptions, IOptions<EntityActionFilterOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>> actionFilterOptions)
        : EntityControllerBase<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}