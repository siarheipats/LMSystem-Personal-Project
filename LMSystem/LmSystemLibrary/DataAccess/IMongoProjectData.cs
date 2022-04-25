
namespace LmSystemLibrary.DataAccess
{
    public interface IMongoProjectData
    {
        Task CreateProject(ProjectModel project);
        Task<ProjectModel> GetPorjectAsync(string id);
        Task<List<ProjectModel>> GetProjectsAsync();
        Task UpdateClient(ProjectModel project);
        Task<List<ProjectModel>> GetCurrentPorjectsAsync();
    }
}