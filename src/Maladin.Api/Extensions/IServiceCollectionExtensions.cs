using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Options;
using Maladin.EFCore.Models.Abstractions;

namespace Maladin.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityActionFilterOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>(this IServiceCollection services, Action<EntityActionFilterOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>> options)
            where TEntity : EntityBase
            where TReadDto : ReadBase
            where TCreateDto : class
            where TUpdateDto : class
        {
            services.AddOptions<EntityActionFilterOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>>().Configure(options).ValidateDataAnnotations().ValidateOnStart();
            return services;
        }

        public static IServiceCollection AddEntityQueryOptions<TEntity, TRead, TCreate, TUpdate>(this IServiceCollection services, Action<CrudOptions<TEntity, TRead, TCreate, TUpdate>> options)
        {
            services.AddOptions<CrudOptions<TEntity, TRead, TCreate, TUpdate>>().Configure(options).ValidateDataAnnotations().ValidateOnStart();
            return services;
        }
    }
}