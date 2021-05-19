using Foodify.Domain.Models.ProductDomain;
using System.Collections.Generic;

namespace Foodify.Domain.Models.CategoryDomain
{
    /// <summary>
    /// Category of a product
    /// </summary>
    public class ProductCategory:BaseNameModel
    {
        /// <summary>
        /// List of products in specified category
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
