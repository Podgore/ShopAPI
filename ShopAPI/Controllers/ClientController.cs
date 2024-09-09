using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.Common.DTOs;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientAsync(Guid clientId)
        {
            var result = await _clientService.GetClientByIdAsync(clientId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTodaysBirtdayClientsAsync()
        {
            var result = await _clientService.GetTodaysBirthdayClientsAsync();
            return Ok(result);
        }

        [HttpGet("numberOfDays")]
        public async Task<IActionResult> GetLatestBuyers(int numberOfDays)
        {
            var result = await _clientService.GetLatestBuyersForNDays(numberOfDays);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertClientAsync(ClientDTO request)
        {
            var result = await _clientService.AddClientAsync(request);
            return Ok(result);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClientAsync(Guid clientId)
        {
            var result = await _clientService.DelereClientByIdAsync(clientId);
            return Ok(result);
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClientAsync(Guid clientId, [FromBody] ClientDTO request)
        {
            var result = await _clientService.UpdateClientAsync(clientId, request);
            return Ok(result);
        }
    }
}
