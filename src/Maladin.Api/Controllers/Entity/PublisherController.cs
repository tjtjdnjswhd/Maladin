using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class PublisherController(MaladinDbContext dbContext, IMapper mapper, ILogger<PublisherController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Publisher, PublisherRead, PublisherCreate, PublisherUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}