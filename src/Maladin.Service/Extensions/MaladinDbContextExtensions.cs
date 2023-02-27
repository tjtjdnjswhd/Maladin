using Maladin.Data;
using Maladin.Data.Models;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace Maladin.Service.Extensions
{
    public static class MaladinDbContextExtensions
    {
        public static bool ConsumePoint(this MaladinDbContext dbContext, int userId, int pointAmount)
        {
            SqlParameter result = new()
            {
                ParameterName = "result",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Bit
            };

            dbContext.Database.ExecuteSqlRaw("usp_ConsumePoint @userId, @pointAmount, @result OUTPUT", new SqlParameter("@userId", userId), new SqlParameter("@pointAmount", pointAmount), result);
            return (bool)result.Value;
        }

        public static bool IsUserNameExist(this MaladinDbContext dbContext, string userName)
        {
            return dbContext.Users.Any(u => u.Name == userName);
        }

        public static bool IsUserEmailExist(this MaladinDbContext dbContext, string email)
        {
            return dbContext.Users.Any(u => u.Email == email);
        }

        public static bool IsExist<TModel>(this MaladinDbContext dbContext, int id) where TModel : EntityBase
        {
            return dbContext.Find<TModel>(id) != null;
        }

        public static async Task<bool> IsExistAsync<TModel>(this MaladinDbContext dbContext, int id, CancellationToken cancellationToken = default) where TModel : EntityBase
        {
            return (await dbContext.FindAsync<TModel>(new object[] { id }, cancellationToken: cancellationToken).ConfigureAwait(false)) != null;
        }

        public static bool IsNameIdentifierDuplicate(this MaladinDbContext dbContext, int providerId, string nameIdentifier)
        {
            return dbContext.OAuthIds.Any(o => o.ProviderId == providerId && o.NameIdentifier == nameIdentifier);
        }
    }
}