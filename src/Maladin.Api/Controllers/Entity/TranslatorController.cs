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
    public class TranslatorController(MaladinDbContext dbContext, IMapper mapper, ILogger<TranslatorController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}