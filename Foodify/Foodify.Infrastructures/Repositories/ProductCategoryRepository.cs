using Foodify.Domain.Models.CategoryDomain;
using Foodify.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodify.Infrastructures.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(FoodifyContext context) : base(context)
        {
        }

        public async Task<ICollection<ProductCategory>> GetAllAsync(string searchString = null, bool ascending = true)
        {
            var searchedCategory = string.IsNullOrEmpty(searchString) ? 
                await _dbEntities.ToListAsync() : 
                await _dbEntities.Where(c => c.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();

            return ascending ? searchedCategory.OrderBy(c => c.Name).ToList() : searchedCategory.OrderByDescending(c => c.Name).ToList();
        }

        public async Task<bool> Exists(string productName)
        {
            var entitis = await _dbEntities.ToListAsync();
            var entity = entitis.FirstOrDefault(e => e.Name.Equals(productName, StringComparison.InvariantCultureIgnoreCase));
            
            if (entity == null)
                return false;

            return true;
        }
    }
}
