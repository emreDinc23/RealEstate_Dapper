using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Dtos.OurServicesDtos;
using RealEstate_Dapper.Repositories.CategoryRepositories;
using RealEstate_Dapper.Repositories.OurServicesRepository;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurServicesController : ControllerBase
    {
        private readonly IOurServicesRepository _ourServicesRepository;
        public OurServicesController(IOurServicesRepository ourServicesRepository)
        {
            _ourServicesRepository = ourServicesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetOurServices()
        {
            var ourServices = await _ourServicesRepository.GetOurServicesAsync();
            return Ok(ourServices);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreateOurServiceDto createOurServiceDto)
        {
            _ourServicesRepository.CreateOurServiceAsync(createOurServiceDto);
            return Ok("Servis Ekleme Başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOurService(int id)
        {
            _ourServicesRepository.DeleteOurServiceAsync(id);
            return Ok("Servis Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceDto updateOurServiceDto)
        {
            _ourServicesRepository.UpdateOurServiceAsync(updateOurServiceDto);
            return Ok("Kategori Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOurService(int id)
        {
            var ourService = await _ourServicesRepository.GetOurService(id);
            return Ok(ourService);
        }


    }
}
