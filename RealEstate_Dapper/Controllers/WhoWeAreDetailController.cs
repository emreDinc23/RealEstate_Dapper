using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper.Repositories.CategoryRepositories;
using RealEstate_Dapper.Repositories.WhoWeAreReporitories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var whoWeAre = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(whoWeAre);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("Hakkımızda Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreRepository.UpdateWhoWeAreDetailDto(updateWhoWeAreDetailDto);
            return Ok("Hakkımızda Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAreDetailDto(id);
            return Ok("Hakkımızda Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoAreDetail(int id)
        {
            var whoAreDetail = await _whoWeAreRepository.GetByIDWhoWeAreDetail(id);
            return Ok(whoAreDetail);
        }
    
}
}
