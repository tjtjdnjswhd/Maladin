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
    public class UserController(MaladinDbContext dbContext, ILogger<UserController> logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<User, UserRead, UserCreate, UserUpdate>> crudOptions, IOptions<EntityActionFilterOptions<User, UserRead, UserCreate, UserUpdate>> actionFilterOptions)
        : EntityControllerBase<User, UserRead, UserCreate, UserUpdate>(dbContext, logger, entityConfiguration, crudOptions, actionFilterOptions)
    {
    }
}