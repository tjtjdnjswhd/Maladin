using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class OAuthProviderController(MaladinDbContext dbContext, IMapper mapper, ILogger<OAuthProviderController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}