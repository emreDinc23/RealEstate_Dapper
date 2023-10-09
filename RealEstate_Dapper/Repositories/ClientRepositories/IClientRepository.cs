using RealEstate_Dapper.Dtos.ClientDtos;

namespace RealEstate_Dapper.Repositories.ClientRepositories
{
    public interface IClientRepository
    {
        Task<List<ResultClient>> GetClientAsync();
        void CreateClientAsync(CreateClientDto createClient);
        void UpdateClientAsync(UpdateClient updateClient);
        void DeleteClientAsync(int id);
        Task<GetByIDClient> GetClient(int id);
    }
}
