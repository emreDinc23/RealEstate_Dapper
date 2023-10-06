

using RealEstate_Dapper.Dtos.PopulerLocationDtos;

namespace RealEstate_Dapper.Repositories.PopulerLocationRepositories
{
    public interface IPopulerLocationRepository
    {
        Task<List<ResultPopulerLocationDto>> GetPopulerLocation();
        void CreatePopulerLocationAsync(CreatePopulerLocationDto createPopulerLocation);
        void UpdatePopulerLocationAsync(UpdatePopulerLocationDto updatePopulerLocation);
        void DeletePopulerLocationAsync(int id);
        Task<GetByIDPopulerLocationDto> GetByIDPopulerLocation(int id);
    }
}
