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
    public class OAuthProviderController(MaladinDbContext dbContext, ILogger<OAuthProviderController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>> crudOptions, IOptions<EntityActionFilterOptions<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>> actionFilterOptions)
        : EntityControllerBase<OAuthProvider, OAuthProviderRead, OAuthProviderCreate, OAuthProviderUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}