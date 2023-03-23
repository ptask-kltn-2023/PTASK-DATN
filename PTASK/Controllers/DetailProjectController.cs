using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class DetailProjectController : Controller
    {
        private readonly IProjectService _project;

        public DetailProjectController(IProjectService project)
        {
            _project = project;
        }
        // GET: DetailProjectController
        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            var result = await _project.GetProjectById(projectId);
            TempData["ProjectID"] = projectId;
            TempData["TitleProject"] = result.name;
            TempData.Keep("ProjectID");
            TempData.Keep("TitleProject");
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Project");

            }
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
