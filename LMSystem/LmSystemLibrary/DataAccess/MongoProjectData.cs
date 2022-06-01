using System;
using Microsoft.Extensions.Caching.Memory;

namespace LmSystemLibrary.DataAccess
{
    public class MongoProjectData : IMongoProjectData
    {
        private readonly IMongoCollection<ProjectModel> _projects;
        private readonly IMemoryCache _cache;
        private const string cacheName = "ProjectData";

        public MongoProjectData(IDbConnection db, IMemoryCache cache)
        {
            _projects = db.ProjectCollection;
            _cache = cache;
        }

        public async Task<List<ProjectModel>> GetProjectsAsync()
        {
            var results = await _projects.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<ProjectModel> GetPorjectAsync(string id)
        {
            var results = await _projects.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public async Task<List<ProjectModel>> GetCurrentPorjectsAsync()
        {
            var results = await _projects.FindAsync(u => u.ProjectStatus == "Current");
            return results.ToList();
        }

        public Task CreateProject(ProjectModel project)
        {
            return _projects.InsertOneAsync(project);
        }

        public Task UpdateProject(ProjectModel project)
        {
            var filter = Builders<ProjectModel>.Filter.Eq("Id", project.Id);
            return _projects.ReplaceOneAsync(filter, project, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteProject(ProjectModel project)
        {
            var filter = Builders<ProjectModel>.Filter.Eq("Id", project.Id);
            _projects.DeleteOne(filter);
        }
    }
}

