using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodify.Domain.Models.ProductDomain
{
    /// <summary>
    /// Product repository contract
    /// </summary>
    public interface IProductRepository:IRepository<Product>
    {
        Task<ICollection<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<bool> ExistsAsync(string productName);
    }
}
