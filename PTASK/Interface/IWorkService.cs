using PTASK.Models;

namespace PTASK.Interface
{
    public interface IWorkService
    {
        Task<List<Work>> GetAllWorkByIdProject(string projectId);
        Task<Work> GetWorkById(string workId);
        Task<List<Work>> GetWorksByName(string name);
        Task<bool> ChangeStatus(string createId, string workId);
        Task<bool> CreateWork(WorkCreate work, string projectId);
        Task<bool> UpdateWork(WorkCreate work, string workId);
        Task<bool> DeleteWork(string workId);
    }
}
