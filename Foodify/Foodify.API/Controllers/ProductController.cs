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

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<ProductOutput>> Get(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);

            if (product == null)
                return NotFound();

            var mappedProduct = product.Adapt<ProductOutput>();

            return Ok(mappedProduct);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductInput productInput)
        {
            if (productInput == null)
                throw new NullReferenceException(nameof(productInput));

            if (await _productRepository.ExistsAsync(productInput.Name))
                return BadRequest($"{productInput} already exists.");

            var mappedProduct = productInput.Adapt<Product>();

            _productRepository.Add(mappedProduct);
            await _productRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductUpdateInput productUpdate)
        {
            var mappedProduct = productUpdate.Adapt<Product>();
            _productRepository.Update(mappedProduct);
            await _productRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<ActionResult> Delete(Guid productId)
        {
            var productFromDb = await _productRepository.GetAsync(productId);

            if (productFromDb == null)
                return NotFound();

            _productRepository.Remove(productFromDb);
            await _productRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
