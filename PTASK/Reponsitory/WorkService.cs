using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;

namespace PTASK.Reponsitory
{
    public class WorkService : IWorkService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;

        public WorkService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }

        public async Task<bool> CreateWork(WorkCreate work, string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiCreateWork");
            string[] outputArray;
            if (work.teamId.Count > 0)
            {
                if (work.teamId[0].IsNullOrEmpty())
                {
                    outputArray = new string[] {};
                }
                else
                {
                    outputArray = work.teamId[0].Split(',');
                }
            }
            else
            {
                outputArray = new string[] {};
            }
            work.createId = _cache.Get<string>("UserId");
            work.leaderId = "6429449e32e69be96008c5a0";
            // Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                work.name,
                startTime = work.startTime.ToString("MM-dd-yyyy"),
                endTime = work.endTime.ToString("MM-dd-yyyy"),
                work.createId,
                teamId = outputArray,
                projectId,
                work.leaderId
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("api/works", jsonContent);
            //Kiểm tra dữ liệu trả về
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteWork(string workId)
        {
            var api = _httpClientFactory.CreateClient("removeWork");
            var response = await api.DeleteAsync($"api/works/{workId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Work>> GetAllWorkByIdProject(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiGetAllWork");
            var response = await api.GetAsync($"api/works/all-work-project/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Work>>(content);
            return result;
        }
    }
}
