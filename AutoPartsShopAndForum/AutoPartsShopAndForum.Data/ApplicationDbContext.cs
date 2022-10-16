namespace AutoPartsShopAndForum.Data
{
    using AutoPartsShopAndForum.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(
                        "Server=DESKTOP-P07L97L\\SQLEXPRESS;Database=AutoPartsAndForum;Trusted_Connection=True",
                        b => b.MigrationsAssembly("AutoPartsShopAndForum"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(t => t.Town)
                .WithMany(t => t.Users)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Town>()
                .HasMany(u => u.Users)
                .WithOne(u => u.Town)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<User>()
                .HasMany(o => o.Orders)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Order>()
                .HasOne(c => c.User)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<User>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Creator)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Product>()
                .HasOne(u => u.Creator)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Product>()
                .HasOne(s => s.Subcategory)
                .WithMany(s => s.Products)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Subcategory>()
                .HasMany(s => s.Products)
                .WithOne(s => s.Subcategory)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Category>()
                .HasMany(s => s.SubCategories)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany(s => s.SubCategories)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Order>()
                .HasOne(o => o.Town)
                .WithMany(t => t.Orders)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Town>()
                .HasMany(t => t.Orders)
                .WithOne(t => t.Town)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<OrderProduct>()
                .HasKey(k => new
                {
                    k.ProductId,
                    k.OrderId
                });

            builder.Entity<MailHistory>()
                .HasOne(p => p.Receiver)
                .WithMany(t => t.MessagesReceived)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MailHistory>()
                .HasOne(p => p.Sender)
                .WithMany(t => t.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PendingSeller>()
                .HasIndex(s => s.UserId)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(u => u.Creator)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>()
                .HasOne(u => u.Creator)
                .WithMany(u => u.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PostCategory>()
                .HasMany(p => p.Posts)
                .WithOne(c => c.PostCategory)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>()
                .HasOne(p => p.PostCategory)
                .WithMany(pc => pc.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(p => p.Post)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<PendingSeller> PendingSellers { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }
        //public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MailHistory> MailsHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
    }
}
