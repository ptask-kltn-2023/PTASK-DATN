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
        private readonly IProjectService _project;
        public JsonController(IMemoryCache cache, 
                              IWorkService work, 
                              ITaskService task, 
                              IUserService user, 
                              ITeamService team,
                              IProjectService project)
        {
            _cache = cache;
            _work = work;
            _task = task;
            _user = user;
            _team = team;
            _project = project;
        }

        #region PROJECT 
        [HttpGet("api/project/getProjectByUserId/{userId}")]
        public async Task<List<Project>> GetJsonProject(string userId)
        {
            var projects = await _project.GetProjectByUserId(userId);
            return projects;
        }
        #endregion

        #region USER
        [HttpGet("api/users/email/{email}")]
        public async Task<User> GetJsonUserByEmail(string email)
        {
            var user = await _user.GetUserByEmail(email);
            return user;
        }

        [HttpGet("api/users/getUserById/{id}")]
        public async Task<User> GetJsonUserById(string id)
        {
            var user = await _user.GetUserById(id);
            return user;
        }

        [HttpGet("api/users/getUserByTaskId/{taskId}")]
        public async Task<List<User>> GetJsonUserByTaskId(string taskId)
        {
            var user = await _user.GetUserByTaskId(taskId);
            return user;
        }
        #endregion

        #region WORK
        [HttpGet("api/works/{projectId}")]
        public async Task<List<Work>> GetJsonAllWorks(string projectId)
        {
            if (projectId != null)
            {
                var works = await _work.GetAllWorkByIdProject(projectId);
                HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
                return works;
            }
            return null;
        }

       [HttpGet("api/work/getWorkById/{workId}")]
       public async Task<Work> GetJsonWorkById(string workId)
        {
            var work = await _work.GetWorkById(workId);

            return work;
        }
        #endregion

        #region TEAM
        [HttpGet("api/teams")]
        public async Task<List<Team>> GetJsonAllTeam()
        {
            string projectId = _cache.Get<string>("ProjectID");
            if(projectId != null)
            {
                var teams = await _team.GetAllTeams(projectId);
                return teams;
            }
            return null;
        }

        [HttpGet("api/teams/getTeamByWorkId/{workId}")]
        public async Task<List<Team>> GetJsonTeamsByWorkId(string workId)
        {
            var teams = await _team.GetTeamByWorkId(workId);

            return teams;
        }

        [HttpGet("api/members/getbyworkid/{workId}")]
        public async Task<List<Team>> GetJsonMembersByWorkId(string workId)
        {
            var members = await _team.GetMembersByWorkId(workId);

            return members;
        }

        [HttpGet("api/members/getmemberbyidteam/{teamId}")]
        public async Task<List<User>> GetJsonMembersByTeamId(string teamId)
        {
            var members = await _team.GetMembersByTeamId(teamId);

            return members;
        }
        #endregion

        #region TASK
        [HttpGet("api/task/getbyid/{taskId}")]
        public async Task<PTask> GetJsonTaskById(string taskId)
        {
            var task = await _task.GetTaskById(taskId);

            return task;
        }

        [HttpGet("api/task/getByWorkId/{workId}")]
        public async Task<List<PTask>> GetJsonTaskByWorkId(string workId)
        {
            var tasks = await _task.GetTasksByWorkId(workId);

            return tasks;
        }
        #endregion
    }
}
