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
    public class RoleController(MaladinDbContext dbContext, ILogger<RoleController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Role, RoleRead, RoleCreate, RoleUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Role, RoleRead, RoleCreate, RoleUpdate>> actionFilterOptions)
        : EntityControllerBase<Role, RoleRead, RoleCreate, RoleUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}