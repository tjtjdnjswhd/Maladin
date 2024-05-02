using Maladin.EFCore;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Maladin.SqlServerMigration
{
    public class MaladinSqlServerDbContext(DbContextOptions<MaladinSqlServerDbContext> options) : MaladinDbContext(options)
    {
        public override async Task<bool> TryConsumePointAsync(int userId, int pointAmount, CancellationToken cancellationToken = default)
        {
            SqlParameter result = new()
            {
                ParameterName = "@result",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Bit
            };

            SqlParameter userIdParam = new()
            {
                ParameterName = "@userId",
                Value = userId
            };

            SqlParameter pointAmountParam = new()
            {
                ParameterName = "@pointAmount",
                Value = pointAmount
            };

            await Database.ExecuteSqlRawAsync("EXECUTE usp_TryConsumePoint @userId, @pointAmount, @result OUTPUT", [result, userIdParam, pointAmountParam], cancellationToken);
            return (bool)result.Value;
        }
    }
}