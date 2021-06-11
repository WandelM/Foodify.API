using Foodify.Domain.Models.CategoryDomain;
using Foodify.Domain.Models.RecipeDomain;
using System;
using System.Collections.Generic;

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
        public Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
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
        /// <summary>
        /// Set of receipes where product exists
        /// </summary>
        public ICollection<Recipe> Recipes { get; set; }
        /// <summary>
        /// Join table configuration with additional data inside
        /// </summary>
        public ICollection<RecipeProducts> RecepieProducts { get; set; }
    }
}
