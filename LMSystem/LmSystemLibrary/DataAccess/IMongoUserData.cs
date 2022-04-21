
namespace LmSystemLibrary.DataAccess
{
    public interface IMongoUserData
    {
        Task CreateUser(UserModel user);
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GeUserAsync(string id);
        Task UpdateClient(UserModel user);
    }
}