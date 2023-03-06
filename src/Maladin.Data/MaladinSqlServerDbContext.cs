using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Maladin.Data
{
    public class MaladinSqlServerDbContext : MaladinDbContext
    {
        public MaladinSqlServerDbContext(DbContextOptions<MaladinSqlServerDbContext> options) : base(options)
        {
        }

        public override bool TryConsumePoint(int userId, int pointAmount)
        {
            SqlParameter result = new()
            {
                ParameterName = "result",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Bit
            };

            Database.ExecuteSqlRaw("usp_ConsumePoint @userId, @pointAmount, @result OUTPUT", new SqlParameter("@userId", userId), new SqlParameter("@pointAmount", pointAmount), result);
            return (bool)result.Value;
        }
    }
}