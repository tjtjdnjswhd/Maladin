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
    public class OAuthIdController(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IEntityConfigurationService configuration, IOptions<CrudOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<OAuthId, OAuthIdRead, OAuthIdCreate, OAuthIdUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}