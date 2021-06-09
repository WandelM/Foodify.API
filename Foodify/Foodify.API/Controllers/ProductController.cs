using Foodify.API.Dtos.Product;
using Foodify.API.Filters;
using Foodify.Domain.Models.ProductDomain;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodify.API.Controllers
{
    [ApiController]
    [Route("/api/products")]
    [Produces("application/json")]
    [ApiKeyFilter]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductOutput>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            if (products.Any() == false)
                return NotFound();

            var mappedProducts = products.Adapt<ICollection<ProductOutput>>();

            return Ok(mappedProducts);
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<ActionResult<ProductOutput>> Get(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);

            if (product == null)
                return NotFound();

            var mappedProduct = product.Adapt<ProductOutput>();
            
            return Ok(mappedProduct);
        }
    }
}
