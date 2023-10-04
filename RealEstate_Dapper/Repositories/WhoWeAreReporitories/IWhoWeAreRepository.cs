using RealEstate_Dapper.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper.Repositories.WhoWeAreReporitories
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        void UpdateWhoWeAreDetailDto(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto );
        void DeleteWhoWeAreDetailDto(int id);
        Task<GetByIDWhoWeAreDetailDto> GetByIDWhoWeAreDetail(int id);
    }
}
