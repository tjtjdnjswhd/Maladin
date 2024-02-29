using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsReviewController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsReviewController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsReview, GoodsReviewRead, GoodsReviewCreate, GoodsReviewUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}