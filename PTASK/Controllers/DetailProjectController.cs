using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class DetailProjectController : Controller
    {
        private readonly IProjectService _project;
        private readonly IWorkService _work;


        public DetailProjectController(IProjectService project, IWorkService work)
        {
            _project = project;
            _work = work;
        }
        // GET: DetailProjectController
        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            var resultProject = await _project.GetProjectById(projectId);
            var resultWork = await _work.GetAllWorkByIdProject(projectId);

            //Gán dữ liệu vào bộ nhớ tạm
            var cache = HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            cache.Set("TitleProject", resultProject.name);
            cache.Set("ProjectID", projectId);

            ViewData["TitleProject"] = cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = cache.Get<string>("ProjectID");

            var detailProject = new DetailProject
            {
                Project = resultProject,
                Works = resultWork,
            };
            return View(detailProject);
        }
        // GET: DetailProjectController/ListWorks
        public IActionResult ListTasks()
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
