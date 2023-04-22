using PTASK.Models;

namespace PTASK.Interface
{
    public interface IAuthService
    {
        Task<string> Login(Auth model);
        Task<string> Register(Auth model);
    }
}
