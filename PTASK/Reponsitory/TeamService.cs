using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;

namespace PTASK.Reponsitory
{
    public class TeamService : ITeamService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;
        private readonly IUserService _user;

        public TeamService(IHttpClientFactory httpClientFactory, IMemoryCache cache, IUserService user)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
            _user = user;
        }

        public async Task<bool> CreateTeam(TeamCreate team, string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiCreateTeam");
            string idUser = _cache.Get<string>("UserId");
            string[] outputMembers;
            if (team.listMembers.Count > 0)
            {
                if (team.listMembers[0].IsNullOrEmpty())
                {
                    outputMembers = new string[] { };
                }
                else
                {
                    outputMembers = team.listMembers[0].Split(',');
                }
            }
            else
            {
                outputMembers = new string[] { };
            }

            string[] outputTeams;
            if (team.listTeams.Count > 0)
            {
                if (team.listTeams[0].IsNullOrEmpty())
                {
                    outputTeams = new string[] { };
                }
                else
                {
                    outputTeams = team.listMembers[0].Split(',');
                }
            }
            else
            {
                outputTeams = new string[] { };
            }


            //Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                team.teamName,
                createId = idUser,
                team.leaderId,
                listMembers = outputMembers,
                listTeams = outputTeams,
                projectId
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PostAsync("api/teams/create", jsonContent);
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

        public async Task<List<Member>> GetAllMembers(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiAllMembers");
            var response = await api.GetAsync($"/api/teams/members-project/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Member>>(content);
            return result;
        }

        public async Task<List<Team>> GetMembersByWorkId(string workId)
        {
            var api = _httpClientFactory.CreateClient("apiMembersByWorkId");
            var response = await api.GetAsync($"/api/teams/teams-work/{workId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Team>>(content);
            return result;
        }

        public async Task<List<Team>> GetAllTeams(string projectId)
        {
            var api = _httpClientFactory.CreateClient("apiAllTeams");
            var response = await api.GetAsync($"/api/teams/teams-project/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Team>>(content);
            return result;
        }

        public async Task<bool> Delete(string teamId)
        {
            return true;
        }
    }
}
