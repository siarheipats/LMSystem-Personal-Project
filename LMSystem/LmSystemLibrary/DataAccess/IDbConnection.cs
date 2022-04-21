
namespace LmSystemLibrary.DataAccess
{
    public interface IDbConnection
    {
        string DbName { get; }
        string UserCollectionName { get; }
        string ProjectCollectionName { get; }
        string InvoiceCollectionName { get; }
        string ClientsCollectionName { get; }
        string ItemsCollectionName { get; }
        MongoClient Client { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        IMongoCollection<ProjectModel> ProjectCollection { get; }
        IMongoCollection<InvoiceModel> InvoiceCollection { get; }
        IMongoCollection<ClientModel> ClientCollection { get; }
        IMongoCollection<ItemModel> ItemCollection { get; }
    }
}