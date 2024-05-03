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
    public class PencilController(MaladinDbContext dbContext, ILogger<PencilController> logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<Pencil, PencilRead, PencilCreate, PencilUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Pencil, PencilRead, PencilCreate, PencilUpdate>> actionFilterOptions) : EntityControllerBase<Pencil, PencilRead, PencilCreate, PencilUpdate>(dbContext, logger, entityConfiguration, crudOptions, actionFilterOptions)
    {
    }
}