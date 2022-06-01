
using Microsoft.Extensions.Caching.Memory;

namespace LmSystemLibrary.DataAccess
{
    public class MongoClientData : IMongoClientData
    {
        private readonly IMongoCollection<ClientModel> _clients;
        private readonly IMemoryCache _cache;
        private const string cacheName = "ClientData";

        public MongoClientData(IDbConnection db, IMemoryCache cache)
        {
            _clients = db.ClientCollection;
            _cache = cache;
        }

        public async Task<List<ClientModel>> GetClientsAsync()
        {
            var results = await _clients.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<ClientModel> GeClientAsync(string id)
        {
            var results = await _clients.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateClient(ClientModel client)
        {
            return _clients.InsertOneAsync(client);
        }

        public Task UpdateClient(ClientModel client)
        {
            var filter = Builders<ClientModel>.Filter.Eq("Id", client.Id);
            return _clients.ReplaceOneAsync(filter, client, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteClient(ClientModel client)
        {
            var filter = Builders<ClientModel>.Filter.Eq("Id", client.Id);
            _clients.DeleteOne(filter);
        }
    }
}

