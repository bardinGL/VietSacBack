using Microsoft.EntityFrameworkCore;

namespace VietSacBackend._3.Repository.Data
{
    public class VietSacContext : DbContext
    {
        IConfiguration _configuration;

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
    }
}
