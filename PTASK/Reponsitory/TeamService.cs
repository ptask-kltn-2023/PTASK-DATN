﻿using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;
using System.Text;
using System.Threading.Tasks;

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

            //Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                team.teamName,
                createId = idUser,
                team.leaderId,
                listMembers = outputMembers,
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

        public async Task<bool> DeleteTeamInProject(string teamId)
        {
            var api = _httpClientFactory.CreateClient("removeTeamInProject");
            var response = await api.DeleteAsync($"/api/teams/{teamId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddMember(Member member, string teamId)
        {
            var api = _httpClientFactory.CreateClient("apiAddMember");
            //Tạo json data
            string[] outputArray;
            if (member.memberIds.Count > 0)
            {
                if (string.IsNullOrEmpty(member.memberIds[0]))
                {
                    outputArray = new string[] { };
                }
                else
                {
                    outputArray = member.memberIds[0].Split(',');
                }
            }
            else
            {
                outputArray = new string[] { };
            }
            string jsonData = JsonConvert.SerializeObject(new
            {
                memberIds = outputArray
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PatchAsync($"api/teams/add-member/{teamId}", jsonContent);
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

        public async Task<List<User>> GetMembersByTeamId(string teamId)
        {
            var api = _httpClientFactory.CreateClient("apiGetMemberByTeamId");
            var response = await api.GetAsync($"/api/teams/members-team/{teamId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(content);
            return result;
        }

        public async Task<List<Team>> GetTeamByWorkId(string workId)
        {
            var api = _httpClientFactory.CreateClient("apiGetTeamByWorkId");
            var response = await api.GetAsync($"/api/teams/teams-work/{workId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Team>>(content);
            return result;
        }

        public async Task<List<Team>> GetTeamsByName(string teamName)
        {
            var projectId = _cache.Get<string>("ProjectID");
            var api = _httpClientFactory.CreateClient("apiGetWorkByName");
            var response = await api.GetAsync($"api/teams/name/{projectId}/{teamName}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Team>>(content);
            return result;
        }

        public async Task<List<string>> GetAllIdLeader()
        {
            var projectId = _cache.Get<string>("ProjectID");
            var api = _httpClientFactory.CreateClient("apiGetAllIdLeader");
            var response = await api.GetAsync($"/api/teams/leader-member/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(content);
            return result;
        }

        public async Task<bool> DeleteMemberInProject(string memberId)
        {
            var api = _httpClientFactory.CreateClient("removeMemberInProject");
            var projectId = _cache.Get<string>("ProjectID");

            //Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                memberId
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PatchAsync($"api/teams/remove-member/{projectId}", jsonContent);
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

        public async Task<Team> GetTeamById(string teamId)
        {
            var api = _httpClientFactory.CreateClient("apiGetTeamById");
            var response = await api.GetAsync($"/api/teams/team/{teamId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Team>(content);
            return result;
        }

        public async Task<bool> UpdateTeam(TeamCreate team, string teamId)
        {
            var api = _httpClientFactory.CreateClient("removeMemberInProject");
            string[] outputArray;
            if (team.listMembers.Count > 0)
            {
                if (string.IsNullOrEmpty(team.listMembers[0]))
                {
                    outputArray = new string[] { };
                }
                else
                {
                    outputArray = team.listMembers[0].Split(',');
                }
            }
            else
            {
                outputArray = new string[] { };
            }
            //Tạo json data
            string jsonData = JsonConvert.SerializeObject(new
            {
                team.teamName,
                team.leaderId,
                listMembers = outputArray
            });
            // Format json
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // Truyền json vào api
            var response = await api.PatchAsync($"api/teams/{teamId}", jsonContent);
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

        public async Task<List<Member>> GetMembersByName(string memberName)
        {
            var projectId = _cache.Get<string>("ProjectID");
            var api = _httpClientFactory.CreateClient("apiGetWorkByName");
            var response = await api.GetAsync($"api/teams/member-project/{projectId}/{memberName}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Member>>(content);
            return result;
        }
    }
}
