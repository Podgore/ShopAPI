using ShopAPI.Common.DTOs;

namespace ShopAPI.BLL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDTO> AddProductAsync(ProductDTO dto);
        public Task<ProductDTO> UpdateProductAsync(Guid productId, ProductDTO dto);
        public Task<bool> DeleteProductByIdAsync(Guid productId);
        public Task<ProductDTO> GetProductByIdAsync(Guid productId);
    }
}
