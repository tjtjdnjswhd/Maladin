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
    public class OAuthProviderController(MaladinDbContext dbContext, IMapper mapper, ILogger<OAuthProviderController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}