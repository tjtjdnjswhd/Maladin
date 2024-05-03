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
    public class AuthorController(MaladinDbContext dbContext, ILogger<AuthorController> logger, IEntityConfigurationService entityConfiguration, IOptions<EntityActionFilterOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>> actionFilterOptions, IOptions<CrudOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>> crudOptions)
        : EntityControllerBase<Author, AuthorRead, AuthorCreate, AuthorUpdate>(dbContext, logger, entityConfiguration, crudOptions, actionFilterOptions)
    {
    }
}