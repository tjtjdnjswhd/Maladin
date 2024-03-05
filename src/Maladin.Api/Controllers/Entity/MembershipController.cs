using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class MembershipController(MaladinDbContext dbContext, IMapper mapper, ILogger<MembershipController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Membership, MembershipRead, MembershipCreate, MembershipUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Membership, MembershipRead, MembershipCreate, MembershipUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}