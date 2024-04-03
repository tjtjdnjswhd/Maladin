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
    public class MembershipController(MaladinDbContext dbContext, ILogger<MembershipController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>> actionFilterOptions)
        : EntityControllerBase<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}