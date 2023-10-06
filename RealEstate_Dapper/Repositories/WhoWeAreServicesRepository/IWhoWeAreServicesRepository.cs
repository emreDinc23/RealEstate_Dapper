using RealEstate_Dapper.Dtos.WhoWeAreServicesDtos;

namespace RealEstate_Dapper.Repositories.WhoWeAreServicesRepository
{
    public interface IWhoWeAreServicesRepository
    {

        Task<List<ResultWhoWeAreServicesDto>> GetResultWhoWeAreServicesDtos();
        void CreateWhoWeAreServicesDto(CreateWhoWeAreServicesDto createWhoWeAreServicesDto);
        void UpdateWhoWeAreServicesDto(UpdateWhoWeAreServicesDto updateWhoWeAreServicesDto);
        void DeleteWhoWeAreServicesDto(int id);
        Task<GetByIDWhoWeAreServicesDto> getByIDWhoWeAreServicesDto(int id);
    }
}
