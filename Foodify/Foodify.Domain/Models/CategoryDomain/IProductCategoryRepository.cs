using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodify.Domain.Models.CategoryDomain
{
    /// <summary>
    /// Products category repository contract
    /// </summary>
    public interface IProductCategoryRepository: IRepository<ProductCategory>
    {
        Task<bool> Exists(string productName);
        Task<ICollection<ProductCategory>> GetAllAsync(string searchString, bool ascending);
    }
}
