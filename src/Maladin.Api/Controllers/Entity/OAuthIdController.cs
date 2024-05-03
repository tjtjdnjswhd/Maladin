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
    public class OAuthIdController(MaladinDbContext dbContext, ILogger logger, IEntityConfigurationService configuration, IOptions<CrudOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>> crudOptions, IOptions<EntityActionFilterOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>> actionFilterOptions)
        : EntityControllerBase<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}