namespace Maladin.Api.Options
{
    public class EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate>
    {
        public Func<HttpContext, ValueTask<bool>> BeforeReadAuthorize { get; set; } = context => ValueTask.FromResult(true);

        public Func<HttpContext, TRead, ValueTask<bool>> ReadAuthorize { get; set; } = (context, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, TCreate, ValueTask<bool>> CreateAuthorize { get; set; } = (context, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, int, TUpdate, ValueTask<bool>> UpdateAuthorize { get; set; } = (context, id, dto) => ValueTask.FromResult(true);

        public Func<HttpContext, int, ValueTask<bool>> DeleteAuthorize { get; set; } = (context, id) => ValueTask.FromResult(true);
    }
}