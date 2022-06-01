using System;
using Microsoft.Extensions.Caching.Memory;

namespace LmSystemLibrary.DataAccess
{
    public class MongoItemData : IMongoItemData
    {
        private readonly IMongoCollection<ItemModel> _items;
        private readonly IMemoryCache _cache;
        private const string cacheName = "ItemData";

        public MongoItemData(IDbConnection db, IMemoryCache cache)
        {
            _items = db.ItemCollection;
            _cache = cache;
        }

        public async Task<List<ItemModel>> GetItemsAsync()
        {
            var results = await _items.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<ItemModel> GetItemAsync(string id)
        {
            var results = await _items.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateItem(ItemModel item)
        {
            return _items.InsertOneAsync(item);
        }

        public Task UpdateItem(ItemModel item)
        {
            var filter = Builders<ItemModel>.Filter.Eq("Id", item.Id);
            return _items.ReplaceOneAsync(filter, item, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteItem(ItemModel item)
        {
            var filter = Builders<ItemModel>.Filter.Eq("Id", item.Id);
            _items.DeleteOne(filter);
        }
    }
}

