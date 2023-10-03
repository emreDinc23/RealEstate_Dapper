using RealEstate_Dapper.Dtos.CategoryDtos;

namespace RealEstate_Dapper.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        void UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        void DeleteCategoryAsync(int id);
        Task<GetByIdDto> GetCategory(int id);
    }

}
