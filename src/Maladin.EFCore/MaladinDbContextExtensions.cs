using Maladin.EFCore.Models.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace Maladin.EFCore
{
    public static class MaladinDbContextExtensions
    {
        public static async Task<bool> IsUserHaveEntityAsync<T>(this MaladinDbContext dbContext, int entityId, int userId, CancellationToken cancellationToken = default)
            where T : EntityBase, IUserRelationEntity
        {
            return await IUserRelationEntityQuery<T>.IsUserIdMatch.Invoke(dbContext, entityId, userId, cancellationToken);
        }

        private static class IUserRelationEntityQuery<T>
            where T : EntityBase, IUserRelationEntity
        {
            public static readonly Func<MaladinDbContext, int, int, CancellationToken, Task<bool>> IsUserIdMatch
                = EF.CompileAsyncQuery(
                    (MaladinDbContext dbContext, int entityId, int userId, CancellationToken cancellationToken) =>
                    dbContext.Set<T>().Any(e => e.Id == entityId && e.UserId == userId));
        }
    }
}