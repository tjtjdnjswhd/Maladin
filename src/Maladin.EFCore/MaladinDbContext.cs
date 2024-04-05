using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;
using Maladin.EFCore.ValueGenerators;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Maladin.EFCore
{
    public class MaladinDbContext(DbContextOptions<MaladinDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<OAuthProvider> OAuthProviders { get; set; }

        public DbSet<OAuthId> OAuthIds { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<GoodsCart> GoodsCart { get; set; }

        public DbSet<OrderSet> OrderSets { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<GoodsOrder> GoodsOrders { get; set; }

        public DbSet<GoodsCategory> GoodsCategories { get; set; }

        public DbSet<GoodsReview> GoodsReviews { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<BookDisplay> BookDisplays { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Translator> Translators { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(u => u.IsLocked).HasDefaultValue(false);
                builder.Property(u => u.IsExpired).HasDefaultValue(false);
                builder.Property(u => u.SignupAt).HasValueGenerator<DateTimeOffsetUtcNowGenerator>().ValueGeneratedOnAdd();

                builder.HasMany(u => u.Roles).WithMany(r => r.Users).UsingEntity("UserRole");

                builder.HasOne(u => u.Membership).WithMany(m => m.Users).HasForeignKey(r => r.MembershipId);

                builder.HasMany(u => u.OAuthIds).WithOne(o => o.User).HasForeignKey(o => o.UserId);
                builder.HasMany(u => u.Points).WithOne(p => p.User).HasForeignKey(p => p.UserId);
                builder.HasMany(u => u.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId);
                builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);
                builder.HasMany(u => u.Cart).WithOne(c => c.User).HasForeignKey(c => c.UserId);
                builder.HasMany(u => u.Reviews).WithOne(r => r.User).HasForeignKey(r => r.UserId);
            });

            modelBuilder.Entity<OAuthProvider>(builder =>
            {
                builder.HasMany(o => o.OAuthIds).WithOne(o => o.Provider).HasForeignKey(o => o.ProviderId);
            });

            modelBuilder.Entity<Goods>(builder =>
            {
                builder.UseTpcMappingStrategy();

                builder.HasOne(g => g.Category).WithMany(c => c.GoodsList).HasForeignKey(g => g.CategoryId);
                builder.HasMany(g => g.Carts).WithOne(c => c.Goods).HasForeignKey(c => c.GoodsId);
                builder.HasMany(g => g.Orders).WithOne(o => o.Goods).HasForeignKey(o => o.GoodsId);
                builder.HasMany(g => g.Reviews).WithOne(r => r.Goods).HasForeignKey(r => r.GoodsId);
            });

            modelBuilder.Entity<GoodsCategory>(builder =>
            {
                builder.HasOne(c => c.Parent).WithMany(c => c.ChildCategories).HasForeignKey(c => c.ParentId);
            });

            modelBuilder.Entity<BookDisplay>(builder =>
            {
                builder.ToTable(tb =>
                {
                    string tableName = tb.Metadata.GetTableName() ?? throw new NullReferenceException();
                    string priceColumnName = tb.Metadata.GetProperty(nameof(BookDisplay.Price)).GetColumnName();

                    tb.HasCheckConstraint($"CK_{tableName}_{priceColumnName}", $"[{priceColumnName}] >= 0");
                });

                builder.HasOne(b => b.Book).WithMany(b => b.BookDisplays).HasForeignKey(b => b.BookId);
                builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
                builder.HasOne(b => b.Translator).WithMany(t => t.Books).HasForeignKey(t => t.TranslatorId);
                builder.HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);
            });

            modelBuilder.Entity<OrderSet>(builder =>
            {
                builder.ToTable(tb =>
                {
                    string tableName = tb.Metadata.GetTableName() ?? throw new NullReferenceException();
                    string usedPointColumnName = tb.Metadata.GetProperty(nameof(OrderSet.UsedPoints)).GetColumnName();
                    tb.HasCheckConstraint($"CK_{tableName}_{usedPointColumnName}", $"[{usedPointColumnName}] >= 0");

                    string invoiceNumberColumnName = tb.Metadata.GetProperty(nameof(OrderSet.InvoiceNumber)).GetColumnName();
                    string deliveryIdColumnName = tb.Metadata.GetProperty(nameof(OrderSet.DeliveryId)).GetColumnName();

                    tb.HasCheckConstraint($"CTK_{tableName}_{invoiceNumberColumnName}_{deliveryIdColumnName}", $"NOT (([{usedPointColumnName}] IS NULL OR [{deliveryIdColumnName}] IS NULL) AND NOT ([{usedPointColumnName}] IS NULL AND [{deliveryIdColumnName}] IS NULL))");
                });

                builder.HasAlternateKey(o => o.Uid);
                builder.Property(o => o.Uid).HasValueGenerator<SequentialGuidValueGenerator>();
                builder.Property(o => o.OrderedAt).HasValueGenerator<DateTimeOffsetUtcNowGenerator>().ValueGeneratedOnAdd();

                builder.HasOne(o => o.Delivery).WithMany(d => d.Orders).HasForeignKey(o => o.DeliveryId);
                builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<OrderSet>(o => o.PaymentId);
                builder.HasMany(o => o.GoodsOrders).WithOne(g => g.OrderSet).HasForeignKey(g => g.OrderSetId);
            });

            modelBuilder.Entity<Point>(builder =>
            {
                builder.ToTable(tb =>
                {
                    string tableName = tb.Metadata.GetTableName() ?? throw new NullReferenceException();

                    string balanceColumnName = tb.Metadata.GetProperty(nameof(Point.Balance)).Name;
                    tb.HasCheckConstraint($"CK_{tableName}_{balanceColumnName}", $"[{balanceColumnName}] >= 0");

                    string amountColumnName = tb.Metadata.GetProperty(nameof(Point.Amount)).Name;
                    tb.HasCheckConstraint($"CK_{tableName}_{amountColumnName}", $"[{amountColumnName}] > 0");
                });
            });
        }

        public async Task<bool> IsUserRelationAsync<T>(int entityId, int userId, CancellationToken cancellationToken = default)
            where T : EntityBase, IUserRelationEntity
        {
            return await IUserRelationEntityQuery<T>.IsUserIdMatch(this, entityId, userId, cancellationToken);
        }

        private static class IUserRelationEntityQuery<T>
            where T : EntityBase, IUserRelationEntity
        {
            private static readonly Func<MaladinDbContext, int, int, CancellationToken, Task<bool>> _isUserIdMatch
                = EF.CompileAsyncQuery(
                    (MaladinDbContext dbContext, int entityId, int userId, CancellationToken cancellationToken) =>
                    dbContext.Set<T>().Any(e => e.Id == entityId && e.UserId == userId));

            public static Task<bool> IsUserIdMatch(MaladinDbContext dbContext, int entityId, int userId, CancellationToken cancellationToken = default)
            {
                return _isUserIdMatch.Invoke(dbContext, entityId, userId, cancellationToken);
            }
        }
    }
}