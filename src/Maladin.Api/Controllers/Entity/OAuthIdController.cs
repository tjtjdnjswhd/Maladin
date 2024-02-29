using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class OAuthIdController(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}