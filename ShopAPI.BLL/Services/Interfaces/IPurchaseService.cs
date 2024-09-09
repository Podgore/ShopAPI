using ShopAPI.Common.DTOs;

namespace ShopAPI.BLL.Services.Interfaces
{
    public interface IPurchaseService
    {
        public Task<PurchaseDTO> AddPurchaseAsync(PurchaseDTO dto);
        public Task<bool> DeletePurchaseByIdAsync(Guid purchaseId);
        public Task<PurchaseResponce> GetPurchaseByIdAsync(Guid purchaseId);
        public Task<List<Tuple<string, int>>> GetPopularCategoriesAsync(Guid clientId);
        public Task<ProductResultResponse> AddProductToPurchaseAsync(Guid purchaseId, List<Guid> productIds);
    }
}
