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

        public AuthService(IHttpClientFactory httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Login(Auth model)
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

                return token;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Register(Auth model)
        {
            //var content = new MultipartFormDataContent();
            //content.Add(new StringContent(model.email), "email");
            //content.Add(new StringContent(model.password), "password");
            //content.Add(new StringContent(model.confirmPassword), "confirmPassword");

            //content.Add(new StringContent(model.fullName), "fullName");
            //content.Add(new StringContent(model.birthday.ToString("MM/dd/yyyy")), "birthday");
            //content.Add(new StringContent(model.address), "address");
            //content.Add(new StringContent(model.phoneNumber), "phoneNumber");
            //content.Add(new StringContent(model.gender.ToString()), "gender");
            //content.Add(new StringContent(model.status.ToString()), "status");

            //var fileContent = new StreamContent(model.avatar.OpenReadStream());
            //content.Add(fileContent, "avatar", model.avatar.FileName);

            //var api = _httpClientFactory.CreateClient("apiRegister");

            //var response = await api.PostAsync("/api/auths/sign-up", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    var token = await response.Content.ReadAsStringAsync();

            //    // Lưu token vào session hoặc cookie
            //    if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
            //    {
            //        _httpContextAccessor.HttpContext.Session.SetString("Token", token);
            //    }
            //    return token;
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }
    }
}
