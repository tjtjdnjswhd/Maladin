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
    public class UserAddressController(MaladinDbContext dbContext, IMapper mapper, ILogger<UserAddressController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}