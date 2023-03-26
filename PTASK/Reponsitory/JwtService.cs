using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PTASK.Interface;
using PTASK.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PTASK.Reponsitory
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public JwtSecurityToken DecodeToken(string token)
        {
            var secretKey = "secretPTASK";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            // Get the claims from the token
            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // Trích xuất thông tin từ token
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                // Xử lý các thông tin từ token
                // ...

                return jwtToken;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi xác thực token
                // ...
                return null;
            }
            // Thiết lập cấu hình cho giải mã token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var validationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretPTASK")),
            //    ValidateIssuer = false,
            //    ValidateAudience = false
            //};

            //// Giải mã token
            //ClaimsPrincipal principal;
            //try
            //{
            //    principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            //}
            //catch (SecurityTokenException ex)
            //{
            //    Console.WriteLine("Invalid token: " + ex.Message);
            //    return null;
            //}
            //return principal;
            // Trích xuất dữ liệu từ token
            //var userId = principal.FindFirstValue("userId");
            //var userName = principal.FindFirstValue("userName");
            //var email = principal.FindFirstValue("email");

            //// Sử dụng dữ liệu trích xuất
            //Console.WriteLine($"User ID: {userId}");
            //Console.WriteLine($"User Name: {userName}");
            //Console.WriteLine($"Email: {email}");
        }

    }
}
