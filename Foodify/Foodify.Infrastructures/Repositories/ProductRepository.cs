using Foodify.Domain.Models.ProductDomain;
using Foodify.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodify.Infrastructures.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FoodifyContext context) : base(context)
        {
        }

        public async Task<ICollection<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
            return await _dbEntities.Include(p => p.ProductCategory)
                                    .Where(p => p.ProductCategoryId.Equals(categoryId))
                                    .ToListAsync();
        }
    }
}
