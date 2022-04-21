
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
            var output = _cache.Get<List<ClientModel>>(cacheName);

            if (output is null)
            {
                var results = await _clients.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
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
    }
}

