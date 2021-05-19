using Foodify.Domain.Models.CategoryDomain;
using Foodify.Infrastructure.DbContexts;

namespace Foodify.Infrastructures.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(FoodifyContext context) : base(context)
        {
        }
    }
}
