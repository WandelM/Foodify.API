using Foodify.Domain.Models.CategoryDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodify.Infrastructures.DbContext.EntityConfigurations
{
    public static class ProductCategoryEntityConfiguration
    {
        public static void AddProductCategoryConfiguration(this ModelBuilder modelBuilder)
        {
            var productCategoryEntity = modelBuilder.Entity<ProductCategory>();
            productCategoryEntity.HasKey(pc => pc.Id);
            productCategoryEntity.Property(pc => pc.Name).HasMaxLength(100);
            productCategoryEntity.Property(pc => pc.Name).IsRequired();
            productCategoryEntity.Property(pc => pc.CreateData).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
