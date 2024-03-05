using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class TranslatorController(MaladinDbContext dbContext, IMapper mapper, ILogger<TranslatorController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}