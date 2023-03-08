using Maladin.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Maladin.Data
{
    public abstract class MaladinDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OAuthId> OAuthIds { get; set; }
        public DbSet<OAuthProvider> OAuthProviders { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<BookBox> BookBoxes { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<PortonePayment> PortonePayments { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookReviewComment> BookReviewComments { get; set; }
        public DbSet<BookDisplay> BookDisplays { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Translator> Translators { get; set; }

        public MaladinDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User", tb => tb.HasCheckConstraint("CTK_User_PasswordHash_IsOAuth", "[IsOAuth] = 1 OR ([PasswordHash] <> null)"));

                builder.HasIndex(nameof(User.Email));
                builder.HasIndex(nameof(User.Name));

                builder.Property(u => u.Name).IsUnicode().HasMaxLength(20);
                builder.Property(u => u.Email).HasMaxLength(255);
                builder.Property(u => u.PasswordHash);
                builder.Property(u => u.SignupAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
                builder.Property(u => u.SignupIp).HasMaxLength(255);
                builder.Property(u => u.UpdateAt);
                builder.Property(u => u.UpdateIp).HasMaxLength(255);
                builder.Property(u => u.LastLoginDate);
                builder.Property(u => u.LastLoginIp).HasMaxLength(255);
                builder.Property(u => u.IsExpired).HasDefaultValue(false);
                builder.Property(u => u.IsLocked).HasDefaultValue(false);
                builder.Property(u => u.IsEmailAuthenticated).HasDefaultValue(false);
                builder.Property(u => u.IsOAuth).HasDefaultValue(false);

                builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
                builder.HasOne(u => u.Membership).WithMany(m => m.Users).HasForeignKey(u => u.MembershipId);
            });

            modelBuilder.Entity<OAuthId>(builder =>
            {
                builder.ToTable("OAuthId");
                builder.Property(o => o.NameIdentifier);

                builder.HasOne(o => o.User).WithMany(u => u.OauthIds).HasForeignKey(u => u.UserId);
                builder.HasOne(o => o.OAuthProvider).WithMany(p => p.OAuthIds).HasForeignKey(u => u.ProviderId);
            });

            modelBuilder.Entity<OAuthProvider>(builder =>
            {
                builder.ToTable("OAuthProvider");
                builder.Property(o => o.Name).IsUnicode().HasMaxLength(255);
            });

            modelBuilder.Entity<UserAddress>(builder =>
            {
                builder.ToTable("UserAddress");
                builder.Property(ua => ua.Address).IsUnicode().HasMaxLength(255);

                builder.HasOne(ua => ua.User).WithMany(u => u.Addresses).HasForeignKey(ua => ua.UserId);
            });

            modelBuilder.Entity<Membership>(builder =>
            {
                builder.ToTable("Membership");
            });

            modelBuilder.Entity<Role>(builder =>
            {
                builder.ToTable("Role");
            });

            modelBuilder.Entity<Point>(builder =>
            {
                builder.ToTable("Point", tb => tb.HasCheckConstraint("CK_Point_Amount", "[Amount] > 0"));
                builder.Property(p => p.ExpireAt);

                builder.HasOne(p => p.User).WithMany(u => u.Points).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<BookBox>(builder =>
            {
                builder.ToTable("BookBox");

                builder.HasOne(bb => bb.User).WithMany(u => u.BookBoxes).HasForeignKey(bb => bb.UserId);
                builder.HasOne(bb => bb.Book).WithMany(b => b.BookBoxes).HasForeignKey(bb => bb.BookId);
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Order");

                builder.Property(o => o.OrderedAt);
                builder.Property(o => o.Address).IsUnicode();
                builder.Property(o => o.Postcode).HasMaxLength(255);
                builder.Property(o => o.InvoiceNumber).HasMaxLength(255);
                builder.Property(o => o.ReceiverName).IsUnicode().HasMaxLength(255);
                builder.Property(o => o.Message).IsUnicode().HasMaxLength(255);
                builder.Property(o => o.PhoneNumber).HasMaxLength(255);
                builder.Property(o => o.OrderState).HasConversion<string>();

                builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
                builder.HasOne(o => o.Delivery).WithMany(d => d.Orders).HasForeignKey(o => o.DeliveryId);
            });

            modelBuilder.Entity<Delivery>(builder =>
            {
                builder.ToTable("Delivery");

                builder.Property(d => d.Name).IsUnicode().HasMaxLength(255);
            });

            modelBuilder.Entity<PortonePayment>(builder =>
            {
                builder.ToTable("IamportPayment", tb =>
                {
                    tb.HasCheckConstraint("CK_IamportPayment_Amount", "[Amount] > 0");
                }).HasIndex(i => i.ImpUid).IsUnique();

                builder.Property(i => i.ImpUid).HasMaxLength(255);
                    
                builder.HasOne(i => i.Order).WithOne(o => o.Payment).HasForeignKey(typeof(PortonePayment), nameof(PortonePayment.OrderId));
            });

            modelBuilder.Entity<OrderBook>(builder =>
            {
                builder.ToTable("OrderBook", tb =>
                {
                    tb.HasCheckConstraint("CK_OrderBook_OrderQty", "[OrderQty] > 0");
                    tb.HasCheckConstraint("CK_OrderBook_PricePerItem", "[PricePerItem] > 0");
                });

                builder.HasOne(ob => ob.Order).WithMany(o => o.OrderBooks).HasForeignKey(ob => ob.OrderId);
                builder.HasOne(ob => ob.Book).WithMany(b => b.OrderBooks).HasForeignKey(ob => ob.BookId);
            });

            modelBuilder.Entity<Book>(builder =>
            {
                builder.ToTable("Book", tb =>
                {
                    tb.HasCheckConstraint("CK_Book_Stock", "[Stock] >= 0");
                    tb.HasCheckConstraint("CK_Book_Sales", "[Sales] >= 0");
                    tb.HasCheckConstraint("CK_Book_Price", "[Price] > 0");
                }).HasIndex(b => b.Isbn).IsUnique(true);

                builder.Property(b => b.Isbn).HasMaxLength(20);
            });

            modelBuilder.Entity<BookReview>(builder =>
            {
                builder.ToTable("BookReview", tb => tb.HasCheckConstraint("CK_BookReview_Rating", "[Rating] >= 1 AND [Rating] <= 5"));

                builder.Property(br => br.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
                builder.Property(br => br.Content).IsUnicode();

                builder.HasOne(br => br.User).WithMany(u => u.BookReviews).HasForeignKey(br => br.UserId);
                builder.HasOne(br => br.Book).WithMany(b => b.BookReviews).HasForeignKey(br => br.BookId);
            });

            modelBuilder.Entity<BookReviewComment>(builder =>
            {
                builder.ToTable("BookReviewComment");

                builder.Property(brc => brc.Content).IsUnicode();

                builder.HasOne(brc => brc.BookReview).WithMany(br => br.BookReviewComments).HasForeignKey(brc => brc.ReviewId);
            });

            modelBuilder.Entity<BookDisplay>(builder =>
            {
                builder.ToTable("BookDisplay");

                builder.Property(bd => bd.Title).IsUnicode();
                builder.Property(bd => bd.Overview).IsUnicode();
                builder.Property(bd => bd.PaperSize).HasMaxLength(255);
                builder.Property(bd => bd.PageCount);
                builder.Property(bd => bd.CoverUrl);
                builder.Property(bd => bd.PublishAt);

                builder.HasOne(bd => bd.Book).WithOne(b => b.BookDisplay).HasForeignKey(typeof(BookDisplay), nameof(BookDisplay.BookId));
                builder.HasOne(bd => bd.Author).WithMany(a => a.BookDisplays).HasForeignKey(bd => bd.AuthorId);
                builder.HasOne(bd => bd.Publisher).WithMany(p => p.BookDisplays).HasForeignKey(bd => bd.PublisherId);
                builder.HasOne(bd => bd.Translator).WithMany(t => t.BookDisplays).HasForeignKey(bd => bd.TranslatorId);
                builder.HasOne(bd => bd.BookCategory).WithMany(bc => bc.BookDisplays).HasForeignKey(bd => bd.CategoryId);
            });

            modelBuilder.Entity<BookCategory>(builder =>
            {
                builder.ToTable("BookCategory").HasIndex(bc => bc.Name).IsUnique();

                builder.Property(bc => bc.Name).IsUnicode().HasMaxLength(255);

                builder.HasOne(bc => bc.Parent).WithMany(bc => bc.Children).HasForeignKey(bc => bc.ParentId);
            });

            modelBuilder.Entity<Publisher>(builder =>
            {
                builder.ToTable("Publisher").HasIndex(p => p.Name).IsUnique();

                builder.Property(p => p.Name).IsUnicode().HasMaxLength(255);
                builder.Property(p => p.Introduce).IsUnicode();
            });

            modelBuilder.Entity<Author>(builder =>
            {
                builder.ToTable("Author").HasIndex(a => a.Name).IsUnique();

                builder.Property(a => a.Name).IsUnicode().HasMaxLength(255);
                builder.Property(a => a.Introduce).IsUnicode();
            });

            modelBuilder.Entity<Translator>(builder =>
            {
                builder.ToTable("Translator").HasIndex(a => a.Name).IsUnique();

                builder.Property(t => t.Name).IsUnicode().HasMaxLength(255);
                builder.Property(a => a.Introduce).IsUnicode();
            });
        }

        public abstract bool TryConsumePoint(int userId, int pointAmount);
    }
}