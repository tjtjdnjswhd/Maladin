using Maladin.Api.Controllers;
using Maladin.Api.Options;
using Maladin.EFCore.Models.Abstractions;

namespace Maladin.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityAuthorizeOptions<TEntityController, TEntity, TReadDto, TCreateDto, TUpdateDto>(this IServiceCollection services, Action<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>> action)
            where TEntityController : EntityControllerBase<TEntity, TReadDto, TCreateDto, TUpdateDto>
            where TEntity : EntityBase
            where TReadDto : class
            where TCreateDto : class
            where TUpdateDto : class
        {
            services.AddOptions<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>>().Configure(action);
            return services;
        }

        public static IServiceCollection AddDefaultEntityAuthorizeOptions<TEntityController, TEntity, TReadDto, TCreateDto, TUpdateDto>(this IServiceCollection services)
            where TEntityController : EntityControllerBase<TEntity, TReadDto, TCreateDto, TUpdateDto>
            where TEntity : EntityBase
            where TReadDto : class
            where TCreateDto : class
            where TUpdateDto : class

        {
            services.AddOptions<EntityAuthorizeOptions<TEntity, TReadDto, TCreateDto, TUpdateDto>>();
            return services;
        }
    }
}