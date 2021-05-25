using Foodify.API.Dtos;
using Foodify.Domain.Models.CategoryDomain;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodify.API.Controllers
{
    [ApiController]
    [Route("/api/productcategory")]
    [Produces("application/json")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository ?? throw new NullReferenceException();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductCategoryDto>>> GetAll(string searchString, bool ascending)
        {
            var categories = await _productCategoryRepository.GetAllAsync(searchString, ascending);

            if (!categories.Any())
                return NotFound();

            var mappedCategories = categories.Adapt<ICollection<ProductCategoryDto>>();

            return Ok(mappedCategories);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<ProductCategoryDto>> Get(Guid categoryId)
        {
            var category = await _productCategoryRepository.GetAsync(categoryId);

            if (category == null)
                return NotFound();

            var mappedCategory = category.Adapt<ProductCategoryDto>();
            return Ok(mappedCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryInput categoryModel)
        {
            var exists = await _productCategoryRepository.Exists(categoryModel.Name);

            if (exists)
                return BadRequest();

            var mappedCategory = categoryModel.Adapt<ProductCategory>();
            _productCategoryRepository.Add(mappedCategory);
            await _productCategoryRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductCategoryUpdate productCategory)
        {
            var mappedCategory = productCategory.Adapt<ProductCategory>();
            _productCategoryRepository.Update(mappedCategory);
            await _productCategoryRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<ActionResult> Delete(Guid categoryId)
        {
            var category = await _productCategoryRepository.GetAsync(categoryId);

            if (category == null)
                return NotFound();

            _productCategoryRepository.Remove(category);
            await _productCategoryRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
