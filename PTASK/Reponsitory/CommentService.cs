using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;

namespace PTASK.Reponsitory
{
    public class CommentService : ICommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;

        public CommentService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }
        public async Task<Comment> CreateCommentTask(Comment comment)
        {
            var api = _httpClientFactory.CreateClient("apiCreateCommentTask");
           
            // Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                comment.text,
                comment.taskId,
                comment.createId
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("api/notes/task", jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Comment>(content);
            return result;
        }

        public async Task<Comment> CreateCommentWork(Comment comment)
        {
            var api = _httpClientFactory.CreateClient("apiCreateCommentWork");

            // Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                comment.text,
                comment.taskId,
                comment.createId
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("api/notes/work", jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Comment>(content);
            return result;
        }

        public async Task<List<Comment>> GetCommentByIdTask(string taskId)
        {
            var api = _httpClientFactory.CreateClient("apiGetCommentByTaskId");
            var response = await api.GetAsync($"/api/notes/task/{taskId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Comment>>(content);

            return result;
        }

        public async Task<List<Comment>> GetCommentByIdWork(string workId)
        {

            var api = _httpClientFactory.CreateClient("apiGetCommentByWorkId");
            var response = await api.GetAsync($"/api/notes/work/{workId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Comment>>(content);

            return result;
        }
    }
}