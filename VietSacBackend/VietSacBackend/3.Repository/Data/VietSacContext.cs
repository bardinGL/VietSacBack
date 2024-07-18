using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VietSacBackend._3.Repository.Data
{
    public class VietSacContext : DbContext
    {
        public VietSacContext()
        {
        }

        public VietSacContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CartEntity> cartEntities { get; set; }
        public DbSet<CategoryEntity> categoryEntities { get; set; }
        public DbSet<OrderEntity> orderEntities { get; set; }
        public DbSet<PaymentMenthodEntity> paymentMenthodEntities { get; set; }
        public DbSet<ShippingMethodEntity> shippingMethodEntities { get; set; }
        public DbSet<ProductEntity> productEntities { get; set; }
        public DbSet<RoleEntity> roleEntities { get; set; }
        public DbSet<UserEntity> userEntities { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        public DbSet<BlogEntity> blogEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
            var strConn = config["ConnectionStrings:VietSac"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
                .Property(o => o.orderTotal)
                .HasColumnType("decimal(38,4)");

            modelBuilder.Entity<CartEntity>()
                .Property(c => c.price)
                .HasColumnType("decimal(38,4)");

            modelBuilder.Entity<CartEntity>()
                .Property(c => c.quantity)
                .HasColumnType("decimal(38,4)");

            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.price)
                .HasColumnType("decimal(38,4)");

            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.quantity)
                .HasColumnType("decimal(38,4)");
        }
    }
}
