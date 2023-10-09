using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.ClientDtos;
using RealEstate_Dapper.Repositories.ClientRepositories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await clientRepository.GetClientAsync();
            return Ok(clients);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDto createClient)
        {
            clientRepository.CreateClientAsync(createClient);
            return Ok("Client Ekleme Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClient updateClient)
        {
            clientRepository.UpdateClientAsync(updateClient);
            return Ok("Client Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCLient(int id)
        {
            clientRepository.DeleteClientAsync(id);
            return Ok("Client Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var category = await clientRepository.GetClient(id);
            return Ok(category);
        }
    }
}
