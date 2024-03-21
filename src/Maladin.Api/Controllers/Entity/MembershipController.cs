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
    public class MembershipController(MaladinDbContext dbContext, IMapper mapper, ILogger<MembershipController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}