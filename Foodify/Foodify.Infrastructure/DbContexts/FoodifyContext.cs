using Microsoft.EntityFrameworkCore;
using Foodify.Domain.Models.CategoryDomain;
using Foodify.Domain.Models.ProductDomain;

namespace Foodify.Infrastructure.DbContexts
{
    public class FoodifyContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public FoodifyContext(DbContextOptions<FoodifyContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductCategory entity configuration
            
            var productCategoryEntity = modelBuilder.Entity<ProductCategory>();
            productCategoryEntity.HasKey(pc => pc.Id);
            productCategoryEntity.Property(pc => pc.Name).HasMaxLength(100);
            productCategoryEntity.Property(pc => pc.Name).IsRequired();
            productCategoryEntity.HasIndex(pc => pc.Name);

            #endregion

            #region Product entity configuration

            var productEntity = modelBuilder.Entity<Product>();
            productEntity.HasKey(p => p.Id);
            productEntity.HasIndex(p => p.Name);
            productEntity.HasOne(p => p.ProductCategory).WithMany(pc => pc.Products).HasForeignKey(p => p.ProductCategoryId);
            productEntity.Property(p => p.Name).HasMaxLength(200).IsRequired();
            productEntity.Property(p => p.Calories).IsRequired();
            productEntity.Property(p => p.Protein).IsRequired();
            productEntity.Property(p => p.Carbs).IsRequired();
            productEntity.Property(p => p.Fat).IsRequired();
            
            #endregion
        }
    }
}
