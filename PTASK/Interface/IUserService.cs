using PTASK.Models;

namespace PTASK.Interface
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetUserByTaskId(string taskId);
    }
}
