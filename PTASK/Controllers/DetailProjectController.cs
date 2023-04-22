using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class DetailProjectController : Controller
    {
        private readonly IProjectService _project;
        private readonly IWorkService _work;
        private readonly ITaskService _task;
        private readonly ITeamService _team;
        public DetailProjectController(IProjectService project, IWorkService work, ITaskService task, ITeamService team)
        {
            _project = project;
            _work = work;
            _task = task;
            _team = team;
        }
        // GET: DetailProjectController
        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            string id;
            Project resultProject;
            List<Work> resultWork;
            List<Member> resultMember;
            List<PTask> resultTask; 

            //Gán dữ liệu vào bộ nhớ tạm
            var cache = HttpContext.RequestServices.GetRequiredService<IMemoryCache>();

            if (!projectId.IsNullOrEmpty())
            {
                cache.Set("ProjectID", projectId);
                id = projectId;
            }
            else
            {
                id = cache.Get<string>("ProjectID");
            }
            resultProject = await _project.GetProjectById(id);
            resultWork = await _work.GetAllWorkByIdProject(id);
            resultTask = await _task.GetAllTasks(id);
            resultMember = await _team.GetAllMembers(id);

            cache.Set("TitleProject", resultProject.name);
            ViewData["TitleProject"] = resultProject.name;

            //var idUser = cache.Get<string>("UserId");

            var detailProject = new DetailProject
            {
                Project = resultProject,
                Works = resultWork,
                PTasks = resultTask,
                Members = resultMember
            };

            return View(detailProject);
        }
        // GET: DetailProjectController/ListWorks
        public IActionResult ListTasks()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }
        // GET: DetailProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
