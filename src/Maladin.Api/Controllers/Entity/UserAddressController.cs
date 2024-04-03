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
    public class UserAddressController(MaladinDbContext dbContext, ILogger<UserAddressController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>> crudOptions, IOptions<EntityActionFilterOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>> actionFilterOptions)
        : EntityControllerBase<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}