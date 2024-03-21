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
    public class AuthorController(MaladinDbContext dbContext, IMapper mapper, ILogger<AuthorController> logger, IEntityConfigurationService entityConfiguration, IOptions<EntityAuthorizeOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>> entityAuthorizeOptions, IOptions<CrudOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>> crudOptions)
        : EntityControllerBase<Author, AuthorRead, AuthorCreate, AuthorUpdate>(dbContext, mapper, logger, entityConfiguration, crudOptions, entityAuthorizeOptions)
    {
    }
}