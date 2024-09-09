using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;
using ShopAPI.DAL.Repository.Interface;

namespace ShopAPI.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductPurchase> _productPurchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IRepository<Purchase> purchaseRepository, IRepository<Client> clientRepository, IRepository<Product> productRepository, IRepository<ProductPurchase> productPurchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _productPurchaseRepository = productPurchaseRepository;
            _mapper = mapper;
        }

        public async Task<PurchaseDTO> AddPurchaseAsync(PurchaseDTO dto)
        {
            var entity = _mapper.Map<Purchase>(dto);

            entity.Date = DateTime.Now;

            await _purchaseRepository.InsertAsync(entity);

            return _mapper.Map<PurchaseDTO>(entity);
        }

        public async Task<bool> DeletePurchaseByIdAsync(Guid purchaseId)
        {
            var entity = await _purchaseRepository.FirstOrDefaultAsync(p => p.Id == purchaseId)
                ?? throw new Exception($"Unable to find purchase with such id: {purchaseId}");

            return await _purchaseRepository.DeleteAsync(entity) ? true : false;
        }

        public async Task<PurchaseResponce> GetPurchaseByIdAsync(Guid purchaseId)
        {
            var entity = await _purchaseRepository.FirstOrDefaultAsync(p => p.Id == purchaseId)
                ?? throw new Exception($"Unable to find purchase with such id: {purchaseId}");

            return _mapper.Map<PurchaseResponce>(entity);
        }


        public async Task<List<Tuple<string, int>>> GetPopularCategoriesAsync(Guid clientId)
        {
            var purchase = await _purchaseRepository
                .Include(p => p.ProductPurchase)
                .ThenInclude(pp => pp.Product)
                .Where(p => p.ClientId == clientId)
                .ToListAsync();

            var allProducts = purchase
                .SelectMany(purchase => purchase.ProductPurchase.Select(pp => pp.Product))
                .ToList();

            List<Tuple<string, int>> categoryCounts = allProducts
                .GroupBy(product => product.Сategory)
                .Select(group => Tuple.Create(group.Key, group.Count()))
                .ToList();

            return categoryCounts;
        }


        public async Task<ProductResultResponse> AddProductToPurchaseAsync(Guid purchaseId, List<Guid> productIds)
        {
            var purchase = await _purchaseRepository.FirstOrDefaultAsync(p => p.Id == purchaseId)
               ?? throw new Exception($"Unable to find purchase with such id: {purchaseId}");

            var response = new ProductResultResponse();

            foreach (var productId in productIds)
            {
                var product = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId);

                if (product == null)
                {
                    response.Failed.Add(productId);
                    continue;
                }

                var entity = new ProductPurchase
                {
                    ProductId = product.Id,
                    PurchaseId = purchase.Id,
                };

                await _productPurchaseRepository.InsertAsync(entity);

                purchase.FullPrice += product.Price;

                response.Success.Add(productId);
            }

            await _purchaseRepository.UpdateAsync(purchase);

            return response;
        }
    }
}
