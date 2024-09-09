using ShopAPI.Common.DTOs;

namespace ShopAPI.BLL.Services.Interfaces
{
    public interface IClientService
    {
        public Task<ClientDTO> AddClientAsync(ClientDTO dto);
        public Task<ClientDTO> GetClientByIdAsync(Guid clientId);
        public Task<bool> DelereClientByIdAsync(Guid clientId);
        public Task<ClientDTO> UpdateClientAsync(Guid clientId, ClientDTO dto);
        public Task<List<ClientDTO>> GetTodaysBirthdayClientsAsync();
        public Task<List<ClientDTO>> GetLatestBuyersForNDays(int numberOfDays);
    }
}
