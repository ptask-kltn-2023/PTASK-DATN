using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;
using PTASK.Models;
using System.Reflection;

namespace PTASK.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _project;
        private readonly IMemoryCache _cache;

        public ProjectController(IProjectService project, IMemoryCache cache)
        {
            _project = project;
            _cache = cache;
        }

        // GET: ProjectController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string userId = _cache.Get<string>("UserId");
            var result = await _project.GetProjectByUserId(userId);
            return View( result);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        // GET: ProjectController/Details/5
        [HttpGet]
        public ActionResult Details(int projectId)
        {

            return View();
        }

        // GET: ProjectController/Create
        public IActionResult Create()
        {
            Project project = new Project();
            
            return PartialView("~/Views/Project/AddProject.cshtml", project);
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            var result = await _project.Create(project);

            if (result)
            {
                return RedirectToAction("Index", "Project");
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
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

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
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
