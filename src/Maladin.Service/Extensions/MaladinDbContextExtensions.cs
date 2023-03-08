using Maladin.Data;
using Maladin.Data.Models;

namespace Maladin.Service.Extensions
{
    public static class MaladinDbContextExtensions
    {
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

        public static int GetOrderTotalAmount(this MaladinDbContext dbContext, int orderId)
        {
            return dbContext.Orders.Where(o => o.Id == orderId).Select(order => order.OrderBooks.Sum(orderBook => orderBook.OrderQty * orderBook.PricePerItem)).SingleOrDefault();
        }

        public static int GetOrderCurrentAmount(this MaladinDbContext dbContext, int orderId)
        {
            return dbContext.Orders.Where(o => o.Id == orderId).Select(order => order.OrderBooks.Sum(orderBook => (orderBook.OrderQty - orderBook.CancelQty) * orderBook.PricePerItem)).SingleOrDefault();
        }
    }
}