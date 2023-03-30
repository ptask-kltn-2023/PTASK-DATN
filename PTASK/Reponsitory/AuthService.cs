using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PTASK.Reponsitory
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtService _jwtService;

        public AuthService(IHttpClientFactory httpClient, IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
        {
            _httpClientFactory = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _jwtService = jwtService;
        }

        public async Task<string> Login(User model)
        {
            var api = _httpClientFactory.CreateClient("apiLogin");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", model.email),
                new KeyValuePair<string, string>("password", model.password)
            });
            var response = await api.PostAsync("/api/auths/sign-in", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonDocument jsonDocument = JsonDocument.Parse(result);
                string token = jsonDocument.RootElement.GetProperty("token").GetString();
                // Lưu token vào session hoặc cookie
                if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("Token", token);
                }
                _jwtService.DecodeToken(token);
                return token;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Register(User model)
        {
            var api = _httpClientFactory.CreateClient("apiRegister");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", model.email),
                new KeyValuePair<string, string>("password", model.password),
                new KeyValuePair<string, string>("confirmPassword", model.confirmPassword),
                new KeyValuePair<string, string>("fullName", model.fullName),
                new KeyValuePair<string, string>("birthday", model.birthday.ToString("MM-dd-yyyy")),
                new KeyValuePair<string, string>("address", model.address),
                new KeyValuePair<string, string>("phoneNumber", model.phoneNumber),
                new KeyValuePair<string, string>("gender", model.gender.ToString()),
                new KeyValuePair<string, string>("avatarImage", model.avatarImage)
            });
            var response = await api.PostAsync("/api/auths/sign-up", content);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                // Lưu token vào session hoặc cookie
                if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("Token", token);
                }
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
