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
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<OrderProduct>()
                .HasKey(k => new
                {
                    k.ProductId,
                    k.OrderId
                });

            base.OnModelCreating(builder);
        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }
        //public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MailHistory> MailsHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
