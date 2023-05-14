using Amazon.Runtime.Internal.Util;
using Microsoft.CodeAnalysis;
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
        public async Task<bool> CreateCommentTask(Comment comment)
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

        public async Task<bool> CreateCommentWork(Comment comment)
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

        public Task<List<Comment>> GetCommentByIdTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentByIdWorl(string workId)
        {
            throw new NotImplementedException();
        }
    }
}