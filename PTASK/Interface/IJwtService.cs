using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PTASK.Interface
{
    public interface IJwtService
    {
        dynamic DecodeToken(string token);
    }
}
