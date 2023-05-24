using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(string projectId);
        Task<Team> GetTeamById(string teamId);
        Task<List<Team>> GetTeamByWorkId(string workId);
        Task<List<Member>> GetAllMembers(string projectId);
        Task<List<Team>> GetMembersByWorkId(string workId);
        Task<List<User>> GetMembersByTeamId(string teamId);
        Task<List<Team>> GetTeamsByName(string teamName);
        Task<bool> CreateTeam(TeamCreate team, string projectId);
        Task<bool> UpdateTeam(TeamCreate team, string teamId);
        Task<bool> AddMember(Member member, string teamId);
        Task<bool> DeleteTeamInProject(string teamId);
        Task<bool> DeleteMemberInProject(string memberId);
        Task<List<string>> GetAllIdLeader();
    }
}
