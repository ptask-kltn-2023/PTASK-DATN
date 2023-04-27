using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(string projectId);
        Task<List<Member>> GetAllMembers(string projectId);
        Task<List<Team>> GetMembersByWorkId(string workId);
        Task<bool> CreateTeam(TeamCreate team, string projectId);
        Task<bool> Delete(string teamId);
    }
}
