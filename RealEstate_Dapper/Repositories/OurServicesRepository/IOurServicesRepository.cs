
using RealEstate_Dapper.Dtos.OurServicesDtos;

namespace RealEstate_Dapper.Repositories.OurServicesRepository
{
    public interface IOurServicesRepository
    {
        Task<List<ResultOurServiceDto>> GetOurServicesAsync();
        void CreateOurServiceAsync(CreateOurServiceDto createOurServiceDto);
        void UpdateOurServiceAsync(UpdateOurServiceDto updateOurServiceDto);
        void DeleteOurServiceAsync(int id);
        Task<GetByIDOurServiceDto> GetOurService(int id);
    }
}
