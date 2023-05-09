using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Reponsitory
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var api = _httpClientFactory.CreateClient("apiGetUserByEmail");
            var response = await api.GetAsync($"/api/users/email/{email}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }

        public async Task<User> GetUserById(string id)
        {
            var api = _httpClientFactory.CreateClient("apiGetUserById");
            var response = await api.GetAsync($"/api/users/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }

        public async Task<List<User>> GetUserByTaskId(string taskId)
        {
            var api = _httpClientFactory.CreateClient("apiGetUserByTaskId");
            var response = await api.GetAsync($"/api/users/tasks/{taskId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(content);
            return result;
        }
    }
}
