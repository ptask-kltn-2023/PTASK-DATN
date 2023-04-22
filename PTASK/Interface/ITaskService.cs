using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITaskService
    {
        Task<List<PTask>> GetAllTasks(string productId);
        Task<bool> CreateTask(PTask task);
        Task<List<PTask>> GetTasksByWorkId(string workId);
    }
}
