
namespace LmSystemLibrary.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _dataBase;
        //TODO: Make sure the appsetting json have neccessary connection string
        private string _connectionId = "MongoDB";

        public string DbName { get; private set; }
        public string UserCollectionName { get; private set; } = "users";
        public string ProjectCollectionName { get; private set; } = "projects";
        public string InvoiceCollectionName { get; private set; } = "invoices";
        public string ClientsCollectionName { get; private set; } = "clients";
        public string ItemsCollectionName { get; private set; } = "items";
        public MongoClient Client { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }
        public IMongoCollection<ProjectModel> ProjectCollection { get; private set; }
        public IMongoCollection<InvoiceModel> InvoiceCollection { get; private set; }
        public IMongoCollection<ClientModel> ClientCollection { get; private set; }
        public IMongoCollection<ItemModel> ItemCollection { get; private set; }

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;

            Client = new MongoClient(_configuration.GetConnectionString(_connectionId));
            DbName = _configuration["DatabaseName"];
            _dataBase = Client.GetDatabase(DbName);

            UserCollection = _dataBase.GetCollection<UserModel>(UserCollectionName);
            ProjectCollection = _dataBase.GetCollection<ProjectModel>(ProjectCollectionName);
            InvoiceCollection = _dataBase.GetCollection<InvoiceModel>(InvoiceCollectionName);
            ClientCollection = _dataBase.GetCollection<ClientModel>(ClientsCollectionName);
            ItemCollection = _dataBase.GetCollection<ItemModel>(ItemsCollectionName);
        }
    }
}

