using System;

namespace Foodify.API.Dtos
{
    public class ProductCategoryDto
    {
        /// <summary>
        /// Id of a product
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of an category
        /// </summary>
        public string Name { get; set; }
    }
}
