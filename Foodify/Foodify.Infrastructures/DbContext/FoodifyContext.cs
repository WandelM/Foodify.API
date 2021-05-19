using Microsoft.EntityFrameworkCore;
using Foodify.Domain.Models.CategoryDomain;
using Foodify.Domain.Models.ProductDomain;
using Foodify.Infrastructures.DbContext.EntityConfigurations;

namespace Foodify.Infrastructure.DbContexts
{
    public class FoodifyContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public FoodifyContext(DbContextOptions<FoodifyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddProductCategoryConfiguration();
            modelBuilder.AddProductConfiguration();
        }
    }
}
