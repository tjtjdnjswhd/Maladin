namespace Maladin.Api.Options
{
    public class EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate>
    {
        public Func<HttpContext, ValueTask<bool>> BeforeReadAuthorize { get; init; } = context => ValueTask.FromResult(true);

        public Func<HttpContext, TRead, ValueTask<bool>> ReadAuthorize { get; init; } = (context, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, TCreate, ValueTask<bool>> CreateAuthorize { get; init; } = (context, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, int, TUpdate, ValueTask<bool>> UpdateAuthorize { get; init; } = (context, id, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, int, ValueTask<bool>> DeleteAuthorize { get; init; } = (context, id) => ValueTask.FromResult(true);
    }
}