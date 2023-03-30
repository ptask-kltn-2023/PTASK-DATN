using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Reponsitory
{
    public class TeamService : ITeamService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TeamService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Team>> GetAllTeams(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiAllTeams");
            var response = await api.GetAsync($"/api/teams/teams/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Team>>(content);
            return result;
        }
    }
}
