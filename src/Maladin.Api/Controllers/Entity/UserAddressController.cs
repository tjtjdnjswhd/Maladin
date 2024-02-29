using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class UserAddressController(MaladinDbContext dbContext, IMapper mapper, ILogger<UserAddressController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<UserAddress, UserAddressRead, UserAddressCreate, UserAddressUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}