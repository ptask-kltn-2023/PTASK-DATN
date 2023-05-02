using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITaskService
    {
        Task<List<PTask>> GetAllTasks(string productId);
        Task<bool> CreateTask(PTask task);
        Task<List<PTask>> GetTasksByWorkId(string workId);
        Task<bool> DeleteTask(string taskId);
        Task<PTask> GetTaskById(string taskId);
        Task<bool> ChangeStatus(string taskId);
    }
}
