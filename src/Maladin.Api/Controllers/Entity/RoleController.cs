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
    public class RoleController(MaladinDbContext dbContext, IMapper mapper, ILogger<RoleController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Role, RoleRead, RoleCreate, RoleUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Role, RoleRead, RoleCreate, RoleUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Role, RoleRead, RoleCreate, RoleUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}