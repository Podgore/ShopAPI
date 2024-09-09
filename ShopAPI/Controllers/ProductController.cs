using Microsoft.AspNetCore.Mvc;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync(Guid productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductAsync(ProductDTO request)
        {
            var result = await _productService.AddProductAsync(request);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(Guid productId)
        {
            var result = await _productService.DeleteProductByIdAsync(productId);
            return Ok(result);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(Guid productId, [FromBody] ProductDTO request)
        {
            var result = await _productService.UpdateProductAsync(productId, request);
            return Ok(result);
        }
    }
}
