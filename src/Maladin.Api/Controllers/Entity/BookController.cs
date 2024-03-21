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
    public class BookController(MaladinDbContext dbContext, IMapper mapper, ILogger<BookController> logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<Book, BookRead, BookCreate, BookUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Book, BookRead, BookCreate, BookUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Book, BookRead, BookCreate, BookUpdate>(dbContext, mapper, logger, entityConfiguration, crudOptions, entityAuthorizeOptions)
    {
    }
}