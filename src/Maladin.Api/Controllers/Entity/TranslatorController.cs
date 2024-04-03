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
    public class TranslatorController(MaladinDbContext dbContext, ILogger<TranslatorController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>> actionFilterOptions)
        : EntityControllerBase<Translator, TranslatorRead, TranslatorCreate, TranslatorUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
    }
}