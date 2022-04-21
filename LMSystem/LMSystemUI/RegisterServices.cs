namespace LMSystemUI
{
	public static class RegisterServices
	{
		public static void ConfigureServices(this WebApplicationBuilder builder)
        {
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddMemoryCache();

			builder.Services.AddSingleton<IDbConnection, DbConnection>();
			builder.Services.AddSingleton<IMongoClientData, MongoClientData>();
			builder.Services.AddSingleton<IMongoInvoiceData, MongoInvoiceData>();
			builder.Services.AddSingleton<IMongoItemData, MongoItemData>();
			builder.Services.AddSingleton<IMongoProjectData, MongoProjectData>();
			builder.Services.AddSingleton<IMongoUserData, MongoUserData>();
		}
	}
}

