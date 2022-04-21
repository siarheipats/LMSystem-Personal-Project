
namespace LmSystemLibrary.DataAccess
{
    public interface IMongoClientData
    {
        Task CreateClient(ClientModel client);
        Task<ClientModel> GeClientAsync(string id);
        Task<List<ClientModel>> GetClientsAsync();
        Task UpdateClient(ClientModel client);
    }
}