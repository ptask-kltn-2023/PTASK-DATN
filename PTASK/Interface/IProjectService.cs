using PTASK.Models;

namespace PTASK.Interface
{
    public interface IProjectService
    {
        Task<List<Project>> List();
        Task<bool> Create(Project project);
        Task<Project> Update(Project project);
        Task<Project> GetProjectById(string projectId);
        Task<Project> Delete(int product);
    }
}
