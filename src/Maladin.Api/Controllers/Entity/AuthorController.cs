using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class AuthorController(MaladinDbContext dbContext, IMapper mapper, ILogger<AuthorController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Author, AuthorRead, AuthorCreate, AuthorUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Author, AuthorRead, AuthorCreate, AuthorUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}