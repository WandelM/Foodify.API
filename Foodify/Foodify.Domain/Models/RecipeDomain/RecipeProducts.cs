using Foodify.Domain.Models.ProductDomain;
using System;

namespace Foodify.Domain.Models.RecipeDomain
{
    public class RecipeProducts
    {
        /// <summary>
        /// Id of a recipe
        /// </summary>
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        /// <summary>
        /// Id of a product
        /// </summary>
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        /// <summary>
        /// Quantity of a product
        /// </summary>
        public double Quantity { get; set; }
    }
}
