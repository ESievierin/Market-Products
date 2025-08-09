using Market.Products.DAL.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.DAL.EF
{
    public sealed class MarketProductsDbContext : DbContext
    {
        public MarketProductsDbContext(DbContextOptions<MarketProductsDbContext> options) :base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }

        public DbSet<ProductDbModel> Products { get; set; } = null!;
        public DbSet<CategoryDbModel> Categories { get; set; } = null!;
        public DbSet<ManufacturerDbModel> Manufacturers { get; set; } = null!;
    }
}
