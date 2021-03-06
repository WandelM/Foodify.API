using Foodify.Domain.Models.CategoryDomain;
using System;

namespace Foodify.API.Dtos.Product
{
    public class ProductOutput
    {
        /// <summary>
        /// Id of an product
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of an product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id of category to where product belongs to
        /// </summary>
        public Guid ProductCategoryId { get; set; }
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
