using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.WhoWeAreServicesDtos;
using RealEstate_Dapper.Repositories.WhoWeAreServicesRepository;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreServicesController : ControllerBase
    {
        private readonly IWhoWeAreServicesRepository _whoWeAreServicesRepository;

        public WhoWeAreServicesController(IWhoWeAreServicesRepository whoWeAreServicesRepository)
        {
            _whoWeAreServicesRepository = whoWeAreServicesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreServicesList()
        {
            var whoWeAre = await _whoWeAreServicesRepository.GetResultWhoWeAreServicesDtos();
            return Ok(whoWeAre);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreServices(CreateWhoWeAreServicesDto  createWhoWeAreServicesDto)
        {
            _whoWeAreServicesRepository.CreateWhoWeAreServicesDto(createWhoWeAreServicesDto);
            return Ok("Hakkımızda Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreServices(UpdateWhoWeAreServicesDto updateWhoWeAreServicesDto)
        {
            _whoWeAreServicesRepository.UpdateWhoWeAreServicesDto(updateWhoWeAreServicesDto);
            return Ok("Hakkımızda Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreServices(int id)
        {
            _whoWeAreServicesRepository.DeleteWhoWeAreServicesDto(id);
            return Ok("Hakkımızda Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoAreDetail(int id)
        {
            var whoAreDetail = await _whoWeAreServicesRepository.getByIDWhoWeAreServicesDto(id);
            return Ok(whoAreDetail);
        }
    }
}
