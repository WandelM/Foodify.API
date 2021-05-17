using System;

namespace Foodify.Domain.Models.ProductDomain
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product:BaseNameModel
    {
        /// <summary>
        /// Id of category to where product belongs
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Calories on 100g of product
        /// </summary>
        public int Calories { get; set; }
        /// <summary>
        /// Proteins on 100g of product
        /// </summary>
        public int Protein { get; set; }
        /// <summary>
        /// Carbs on 100g of product
        /// </summary>
        public int Carbs { get; set; }
        /// <summary>
        /// Fat on 100g of product
        /// </summary>
        public int Fat { get; set; }
    }
}
