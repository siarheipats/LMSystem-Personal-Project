using System;
using Microsoft.Extensions.Caching.Memory;

namespace LmSystemLibrary.DataAccess
{
    public class MongoUserData : IMongoUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        private readonly IMemoryCache _cache;
        private const string cacheName = "UserData";

        public MongoUserData(IDbConnection db, IMemoryCache cache)
        {
            _users = db.UserCollection;
            _cache = cache;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var output = _cache.Get<List<UserModel>>(cacheName);

            if (output is null)
            {
                var results = await _users.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }

        public async Task<UserModel> GeUserAsync(string id)
        {
            var results = await _users.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return _users.InsertOneAsync(user);
        }

        public Task UpdateClient(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}

