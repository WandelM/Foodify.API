using Foodify.Domain.Models.ProductDomain;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructures.DbContext.EntityConfigurations
{
    public static class ProductEntityConfiguration
    {
        public static void AddProductConfiguration(this ModelBuilder modelBuilder)
        {
            var productEntity = modelBuilder.Entity<Product>();
            productEntity.HasKey(p => p.Id);
            productEntity.HasIndex(p => p.Name);
            productEntity.HasOne(p => p.ProductCategory).WithMany(pc => pc.Products).HasForeignKey(p => p.ProductCategoryId);
            productEntity.Property(p => p.Name).HasMaxLength(200).IsRequired();
            productEntity.Property(p => p.Calories).IsRequired();
            productEntity.Property(p => p.Protein).IsRequired();
            productEntity.Property(p => p.Carbs).IsRequired();
            productEntity.Property(p => p.Fat).IsRequired();
            productEntity.Property(p => p.CreateData).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
