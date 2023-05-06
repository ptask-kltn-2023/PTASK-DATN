using PTASK.Models;

namespace PTASK.Interface
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectByUserId(string userId);
        Task<List<Project>> GetAllProject();
        Task<bool> Create(Project project);
        Task<Project> Update(Project project);
        Task<Project> GetProjectById(string projectId);
        Task<bool> DeleteProject(string projectId);
    }
}
