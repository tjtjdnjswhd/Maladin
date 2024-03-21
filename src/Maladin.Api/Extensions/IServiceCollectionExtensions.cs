using Maladin.Api.Controllers.Entity;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Options;
using Maladin.EFCore.Models.Abstractions;

namespace Maladin.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>(this IServiceCollection services, Action<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>> options)
            where TEntity : EntityBase
            where TReadDto : ReadBase
            where TCreateDto : class
            where TUpdateDto : class
        {
            services.AddOptions<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>>().Configure(options);
            return services;
        }

        public static IServiceCollection AddDefaultEntityAuthorizeOptions<TEntityController, TEntity, TReadDto, TCreateDto, TUpdateDto>(this IServiceCollection services)
            where TEntityController : EntityControllerBase<TEntity, TReadDto, TCreateDto, TUpdateDto>
            where TEntity : EntityBase
            where TReadDto : ReadBase
            where TCreateDto : class
            where TUpdateDto : class

        {
            services.AddOptions<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>>();
            return services;
        }

        public static IServiceCollection AddEntityQueryOptions<TEntity, TRead, TCreate, TUpdate>(this IServiceCollection services, Action<CrudOptions<TEntity, TRead, TCreate, TUpdate>> options)
        {
            services.AddOptions<CrudOptions<TEntity, TRead, TCreate, TUpdate>>().Configure(options).ValidateDataAnnotations().ValidateOnStart();
            return services;
        }
    }
}