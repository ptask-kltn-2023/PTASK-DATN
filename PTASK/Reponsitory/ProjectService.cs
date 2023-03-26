using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace PTASK.Reponsitory
{
    public class ProjectService : IProjectService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProjectService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(Project project)
        {
            var api = _httpClientFactory.CreateClient("apiCreateProject");
            // Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                project.name,
                startTime = project.startTime.ToString("MM-dd-yyyy"),
                endTime = project.endTime.ToString("MM-dd-yyyy"),
                project.mainProject,
                teamIds = project.teamIds ?? new string[] { }
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("/api/v1/projects/create", jsonContent);
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

        public async Task<Project> Delete(int project)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectById(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiGetProjectById");
            var response = await api.GetAsync($"/api/v1/projects/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Project>(content);
            return result;
        }

        public async Task<List<Project>> List()
        {
            var api = _httpClientFactory.CreateClient("apiAllProject");
            var response = await api.GetAsync("/api/v1/projects");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Project>>(content);
            return result;
        }

        public async Task<Project> Update(Project product)
        {
            throw new NotImplementedException();
        }
    }
}
