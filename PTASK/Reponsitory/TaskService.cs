using Amazon.Runtime.Internal.Util;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace PTASK.Reponsitory
{
    public class TaskService : ITaskService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;
        public TaskService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }

        public async Task<bool> ChangeStatus(string taskId)
        {
            var taskUpdateStatus = new PTask { status = true };
            var json = System.Text.Json.JsonSerializer.Serialize(taskUpdateStatus);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var api = _httpClientFactory.CreateClient("changeStatusTask");
            var response = await api.PatchAsync($"/api/tasks/update-status/{taskId}", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CreateTask(PTask task)
        {
            var api = _httpClientFactory.CreateClient("apiCreateTask");
            string[] outputArray;
            if (task.membersId.Count > 0)
            {
                if (string.IsNullOrEmpty(task.membersId[0]))
                {
                    outputArray = new string[] { };
                }
                else
                {
                    outputArray = task.membersId[0].Split(',');
                }
            }
            else
            {
                outputArray = new string[] { };
            }
            // Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                task.name,
                startDay = task.startDay.ToString("MM-dd-yyyy"),
                task.description,
                endDay = task.startDay.ToString("MM-dd-yyyy"),
                startHour = task.startHour.ToString("HH:mm"),
                endHour = task.endHour.ToString("HH:mm"),
                task.workId,
                members = outputArray,
                task.level
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("/api/tasks/", jsonContent);
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

        public async Task<bool> DeleteTask(string taskId)
        {
            var api = _httpClientFactory.CreateClient("removeTask");
            var response = await api.DeleteAsync($"/api/tasks/{taskId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<PTask>> GetAllTasks(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiAllTask");
            var response = await api.GetAsync($"/api/tasks/get-task-in-project/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PTask>>(content);

            return result;
        }

        public async Task<PTask> GetTaskById(string taskId)
        {
            var api = _httpClientFactory.CreateClient("apiGetTaskById");
            var response = await api.GetAsync($"/api/tasks/{taskId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PTask>(content);

            return result;
        }

        public Task<List<PTask>> GetTasksByWorkId(string workId)
        {
            throw new NotImplementedException();
        }
    }
}
