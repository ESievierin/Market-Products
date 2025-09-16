using Market.Products.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDbModel>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CategoryDbModel>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ManufacturerDbModel>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
