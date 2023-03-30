using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Reponsitory
{
    public class TaskService : ITaskService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TaskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<PTask>> GetAllTasks(string productId)
        {
            var api = _httpClientFactory.CreateClient("apiAllTask");
            var response = await api.GetAsync($"/api/tasks/get-task-in-project/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PTask>>(content);

            return result;
        }
    }
}
