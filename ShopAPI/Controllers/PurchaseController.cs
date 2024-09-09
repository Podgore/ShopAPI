using Microsoft.AspNetCore.Mvc;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseAsync(Guid purchaseId)
        {
            var result = await _purchaseService.GetPurchaseByIdAsync(purchaseId);
            return Ok(result);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetPopularCategoriesAsync(Guid clientId)
        {
            var result = await _purchaseService.GetPopularCategoriesAsync(clientId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPurchaseAsync(PurchaseDTO request)
        {
            var result = await _purchaseService.AddPurchaseAsync(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductToPurchaseAsync(Guid purchaseId, List<Guid> productIds)
        {
            var result = await _purchaseService.AddProductToPurchaseAsync(purchaseId, productIds);
            return Ok(result);
        }

        [HttpDelete("{purchaseId}")]
        public async Task<IActionResult> DeletePurchaseAsync(Guid purchaseId)
        {
            var result = await _purchaseService.DeletePurchaseByIdAsync(purchaseId);
            return Ok(result);
        }
    }
}
