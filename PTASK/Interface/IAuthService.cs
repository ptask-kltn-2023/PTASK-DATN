using PTASK.Models;

namespace PTASK.Interface
{
    public interface IAuthService
    {
        Task<string> Login(User model);
        Task<string> Register(User model);
    }
}
