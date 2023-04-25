using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public ProjectService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }
        public async Task<bool> Create(Project project)
        {
            var api = _httpClientFactory.CreateClient("apiCreateProject");
            project.mainProject = _cache.Get<string>("UserId");
           
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(project.name),"name");
            content.Add(new StringContent(project.mainProject), "mainProject");
            content.Add(new StringContent(project.startTime.ToString("MM-dd-yyyy")), "startTime");
            content.Add(new StringContent(project.endTime.ToString("MM-dd-yyyy")), "endTime");
            if (project.teamIds != null)
            {
                foreach (var teamId in project.teamIds)
                {
                    content.Add(new StringContent(teamId), "teamIds");
                }
            }
            else
            {
                content.Add(new StringContent(""), "teamIds");
            }
            var fileContent = new StreamContent(project.BackgroundFile.OpenReadStream());
            content.Add(fileContent, "background", project.BackgroundFile.FileName);
            
            var response = await api.PostAsync("/api/projects/create", content);
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
            var response = await api.GetAsync($"/api/projects/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Project>(content);
            return result;
        }

        public async Task<List<Project>> List()
        {
            var api = _httpClientFactory.CreateClient("apiAllProject");
            var response = await api.GetAsync("/api/projects");
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
