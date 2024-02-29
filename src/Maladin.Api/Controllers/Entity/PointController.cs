using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class PointController(MaladinDbContext dbContext, IMapper mapper, ILogger<PointController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Point, PointRead, PointCreate, PointUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Point, PointRead, PointCreate, PointUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}