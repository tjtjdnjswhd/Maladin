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
    public class PublisherController(MaladinDbContext dbContext, ILogger<PublisherController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>> actionFilterOptions)
        : EntityControllerBase<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}