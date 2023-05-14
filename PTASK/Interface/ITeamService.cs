using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(string projectId);
        Task<List<Team>> GetTeamByWorkId(string workId);
        Task<List<Member>> GetAllMembers(string projectId);
        Task<List<Team>> GetMembersByWorkId(string workId);
        Task<List<User>> GetMembersByTeamId(string teamId);
        Task<List<Team>> GetTeamsByName(string teamName);
        Task<bool> CreateTeam(TeamCreate team, string projectId);
        Task<bool> AddMember(Member member, string teamId);
        Task<bool> DeleteTeamInProject(string teamId, string projectId);
        
        Task<List<string>> GetAllIdLeader();
    }
}
