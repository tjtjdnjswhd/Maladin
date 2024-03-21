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
    public class UserController(MaladinDbContext dbContext, IMapper mapper, ILogger<UserController> logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<User, UserRead, UserCreate, UserUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<User, UserRead, UserCreate, UserUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<User, UserRead, UserCreate, UserUpdate>(dbContext, mapper, logger, entityConfiguration, crudOptions, entityAuthorizeOptions)
    {
    }
}