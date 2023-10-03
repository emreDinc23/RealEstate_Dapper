using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Repositories.CategoryRepositories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryRepository.GetAllCategoryAsync();
            return Ok(categories); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            categoryRepository.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            categoryRepository.DeleteCategoryAsync(id);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryRepository.GetCategory(id);
            return Ok(category);
        }
    }
  
}
