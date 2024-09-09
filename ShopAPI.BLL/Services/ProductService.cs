using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;
using ShopAPI.DAL.Repository.Interface;

namespace ShopAPI.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepository, IMapper mapper) 
        { 
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);

            await _productRepository.InsertAsync(entity);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<bool> DeleteProductByIdAsync(Guid productId)
        {
            var entity = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId)
                ?? throw new Exception($"Unable to find product with such id: {productId}");

            return await _productRepository.DeleteAsync(entity) ? true : false;
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid productId)
        {
            var entity = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId)
                ?? throw new Exception($"Unable to find product with such id: {productId}");

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> UpdateProductAsync(Guid productId, ProductDTO dto)
        {
            var entity = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId)
                ?? throw new Exception($"Unable to find product with such id: {productId}");

            _mapper.Map(dto, entity);

            await _productRepository.UpdateAsync(entity);

            return _mapper.Map<ProductDTO>(entity);
        }
    }
}
