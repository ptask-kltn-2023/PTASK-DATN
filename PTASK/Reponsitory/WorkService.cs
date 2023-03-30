using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;

namespace PTASK.Reponsitory
{
    public class WorkService : IWorkService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WorkService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateWork(Work work)
        {
            return true;
            //var api = _httpClientFactory.CreateClient("apiCreateWork");
            //// Tạo json data
            //string jsonData = JsonConvert.SerializeObject(new
            //{
            //    work.name,
            //    startTime = work.startTime.ToString("MM-dd-yyyy"),
            //    endTime = work.endTime.ToString("MM-dd-yyyy"),
            //    work.createId,
            //    work.teamId,
            //    work.projectId
            //});
            //// Format json
            //var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //// Truyền json vào api
            //var response = await api.PostAsync("api/v1/works", jsonContent);
            ////Kiểm tra dữ liệu trả về
            //if (response.IsSuccessStatusCode)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
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
