using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodify.API.Dtos
{
    public class ProductCategoryUpdate
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
