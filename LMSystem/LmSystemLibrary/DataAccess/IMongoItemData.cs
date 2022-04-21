
namespace LmSystemLibrary.DataAccess
{
    public interface IMongoItemData
    {
        Task CreateItem(ItemModel item);
        Task<ItemModel> GetItemAsync(string id);
        Task<List<ItemModel>> GetItemsAsync();
        Task UpdateItem(ItemModel item);
    }
}