using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;
using PTASK.Models;
using System.IO;

namespace PTASK.Controllers
{
    public class JsonController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IWorkService _work;
        private readonly ITaskService _task;
        private readonly IUserService _user;
        private readonly ITeamService _team;

        public JsonController(IMemoryCache cache, IWorkService work, ITaskService task, IUserService user, ITeamService team)
        {
            _cache = cache;
            _work = work;
            _task = task;
            _user = user;
            _team = team;
        }

        #region user
        [HttpGet("api/users/email/{email}")]
        public async Task<User> GetJsonUserByEmail(string email)
        {
            var user = await _user.GetUserByEmail(email);
            return user;
        }
        #endregion

        #region work
        [HttpGet("api/works")]
        public async Task<List<Work>> GetJsonAllWorks()
        {
            string projectId = _cache.Get<string>("ProjectID");
            var teams = await _work.GetAllWorkByIdProject(projectId);
            return teams;
        }

        #endregion

        #region team
        [HttpGet("api/teams")]
        public async Task<List<Team>> GetJsonAllTeam()
        {
            string projectId = _cache.Get<string>("ProjectID");
            var teams = await _team.GetAllTeams(projectId);
            return teams;
        }

        [HttpGet("api/members/getbyworkid/{workId}")]
        public async Task<List<Team>> GetJsonMembersByWorkId(string workId)
        {
            var members = await _team.GetMembersByWorkId(workId);

            return members;
        }
        #endregion

        #region task
        [HttpGet("api/task/getbyid/{taskId}")]
        public async Task<PTask> GetJsonTaskById(string taskId)
        {
            var task = await _task.GetTaskById(taskId);

            return task;
        }
        #endregion
    }
}
