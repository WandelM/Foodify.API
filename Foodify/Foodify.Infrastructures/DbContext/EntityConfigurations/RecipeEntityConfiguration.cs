using Foodify.Domain.Models.RecipeDomain;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructures.DbContext.EntityConfigurations
{
    public static class RecipeEntityConfiguration
    {
        public static void AddReciprEntityConfiguration(this ModelBuilder modelBuilder)
        {
            var model = modelBuilder.Entity<Recipe>();
            model.HasKey(r => r.Id);
            model.HasIndex(r => r.Name).IsUnique();
            model.Property(r => r.CreateData).HasDefaultValueSql("GETUTCDATE()");
            model.Property(r => r.Name).IsRequired()
                                       .HasMaxLength(200);

            model.HasMany(r => r.Products)
                 .WithMany(p => p.Recipes)
                 .UsingEntity<RecipeProducts>(p => p.HasOne(pr => pr.Product).WithMany(p => p.RecepieProducts).HasForeignKey(pr => pr.ProductId),
                                              r => r.HasOne(pr => pr.Recipe).WithMany(r => r.RecepieProducts).HasForeignKey(pr => pr.RecipeId));
        }
    }
}
