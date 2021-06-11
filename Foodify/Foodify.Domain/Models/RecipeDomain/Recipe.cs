using Foodify.Domain.Models.ProductDomain;
using System.Collections.Generic;

namespace Foodify.Domain.Models.RecipeDomain
{
    public class Recipe : BaseNameModel
    {
        /// <summary>
        /// Category of an recipe
        /// </summary>
        public RecipeCategory RecipeCategory { get; set; }
        /// <summary>
        /// List of products in recipes
        /// </summary>
        public ICollection<Product> Products { get; set; }
        /// <summary>
        /// Join table configuration with additional data inside
        /// </summary>
        public ICollection<RecipeProducts> RecepieProducts { get; set; }
    }
}
