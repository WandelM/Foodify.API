using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodify.Domain.Models.ProductDomain
{
    /// <summary>
    /// Product repository contract
    /// </summary>
    interface IProductRepository:IRepository<Product>
    {
        Task<ICollection<Product>> GetProductsByCategory(Guid categoryId);
    }
}
