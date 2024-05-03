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
    public class BookController(MaladinDbContext dbContext, ILogger<BookController> logger, IEntityConfigurationService entityConfiguration, IOptions<CrudOptions<Book, BookRead, BookCreate, BookUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Book, BookRead, BookCreate, BookUpdate>> actionFilterOptions)
        : EntityControllerBase<Book, BookRead, BookCreate, BookUpdate>(dbContext, logger, entityConfiguration, crudOptions, actionFilterOptions)
    {
    }
}