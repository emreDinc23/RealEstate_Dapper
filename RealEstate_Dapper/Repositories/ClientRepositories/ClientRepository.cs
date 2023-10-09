using Dapper;
using RealEstate_Dapper.Dtos.ClientDtos;
using RealEstate_Dapper.Dtos.OurServicesDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.ClientRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _context;

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public async void CreateClientAsync(CreateClientDto createClient)
        {
            string query = "INSERT INTO Client (Name, Title, Comment,Status) VALUES (@name, @title, @comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("name", createClient.Name);
            parameters.Add("title", createClient.Title);
            parameters.Add("comment", createClient.Comment);
            parameters.Add("status", true);




            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteClientAsync(int id)
        {

            string query = "Delete From Client Where ID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDClient> GetClient(int id)
        {

            string query = "SELECT * FROM Client WHERE ID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDClient>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultClient>> GetClientAsync()
        {
            string query = "SELECT * FROM Client";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultClient>(query);
                return values.ToList();
            }
        }

        public async void UpdateClientAsync(UpdateClient updateClient)
        {
            var query = "UPDATE Client SET Name= @name,Title= @title,Comment=@comment,Status=@status WHERE ID= @id;";
            var parameters = new DynamicParameters();
            parameters.Add("name", updateClient.Name);
            parameters.Add("title", updateClient.Title);
            parameters.Add("comment", updateClient.Comment);
            parameters.Add("status", updateClient.Status);



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
