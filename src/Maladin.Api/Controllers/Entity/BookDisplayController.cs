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
    public class BookDisplayController(MaladinDbContext dbContext, IMapper mapper, ILogger<BookDisplayController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<BookDisplay, BookDisplayRead, BookDisplayCreate, BookDisplayUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}