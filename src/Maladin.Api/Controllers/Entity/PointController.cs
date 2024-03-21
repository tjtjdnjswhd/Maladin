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
    public class PointController(MaladinDbContext dbContext, IMapper mapper, ILogger<PointController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Point, PointRead, PointCreate, PointUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Point, PointRead, PointCreate, PointUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Point, PointRead, PointCreate, PointUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}