using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITaskService
    {
        Task<List<PTask>> GetAllTasks(string productId);
    }
}
