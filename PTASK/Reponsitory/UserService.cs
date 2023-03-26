﻿using Newtonsoft.Json;
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
            var response = await api.GetAsync($"/api/v1/users/email/{email}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}