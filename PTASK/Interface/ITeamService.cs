using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(string projectId);

    }
}
