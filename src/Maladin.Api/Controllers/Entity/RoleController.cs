using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class RoleController(MaladinDbContext dbContext, IMapper mapper, ILogger<RoleController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Role, RoleRead, RoleCreate, RoleUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Role, RoleRead, RoleCreate, RoleUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}