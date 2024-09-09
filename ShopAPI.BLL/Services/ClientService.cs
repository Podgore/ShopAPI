using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;
using ShopAPI.DAL.Repository.Interface;

namespace ShopAPI.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IMapper _mapper;

        public ClientService(IRepository<Client> clientRepository, IRepository<Purchase> purchaseRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> AddClientAsync(ClientDTO dto)
        {
            if (dto.Birthday > DateTime.Now)
            {
                throw new Exception("Birthday date must be lower than now");
            }

            var entity = _mapper.Map<Client>(dto);

            entity.DateOfRegistration = DateTime.Now;

            await _clientRepository.InsertAsync(entity);

            return _mapper.Map<ClientDTO>(entity);
        }

        public async Task<ClientDTO> GetClientByIdAsync(Guid clientId)
        {
            var entity = await _clientRepository.FirstOrDefaultAsync(e => e.Id == clientId)
                ?? throw new Exception($"Unable to find client with such id: {clientId}");

            return _mapper.Map<ClientDTO>(entity);
        }

        public async Task<bool> DelereClientByIdAsync(Guid clientId)
        {
            var entity = await _clientRepository.FirstOrDefaultAsync(e => e.Id == clientId)
               ?? throw new Exception($"Unable to find client with such id: {clientId}");

            return await _clientRepository.DeleteAsync(entity) ? true : false;
        }

        public async Task<ClientDTO> UpdateClientAsync(Guid clientId, ClientDTO dto)
        {
            var entity = await _clientRepository.FirstOrDefaultAsync(e => e.Id == clientId)
               ?? throw new Exception($"Unable to find client with such id: {clientId}");

            _mapper.Map(dto, entity);

            await _clientRepository.UpdateAsync(entity);

            return _mapper.Map<ClientDTO>(entity);
        }

        public async Task<List<ClientDTO>> GetTodaysBirthdayClientsAsync()
        {
            var entities = await _clientRepository
                .Where(c => c.Birthday.Day == DateTime.Now.Day && c.Birthday.Month == DateTime.Now.Month)
                .ToListAsync();

            return _mapper.Map<List<ClientDTO>>(entities);
        }

        public async Task<List<ClientDTO>> GetLatestBuyersForNDays(int numberOfDays)
        {
            var timeFrom = DateTime.Now.AddDays(-numberOfDays);

            var purchases = await _purchaseRepository.Include(p => p.Client).Where(p => p.Date > timeFrom).ToListAsync();

            var clients = purchases.Select(p => p.Client).ToList();

            return _mapper.Map<List<ClientDTO>>(clients);
        }
    }
}
