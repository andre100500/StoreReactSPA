using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.DTOs.UpdateDTOs;
using StoreReactSPA.Server.Services.Inteface;

namespace StoreReactSPA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_productService.GetAllProductsAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_productService.GetProductByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createDto)
        {
            var newProduct = await _productService.CreateProductAsync(createDto);
            return CreatedAtAction(nameof(Create),new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto updateDto)
        {
            return Ok( await _productService.UpdateProductAsync(id, updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] string? search, [FromQuery] string? category)
        {
            var products = await _productService.SearchProductsAsync(search, category);

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Description = p.Description,
            });

            return Ok(result);
        }
    }
}
