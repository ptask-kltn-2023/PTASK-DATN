using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _project;

        public ProjectController(IProject project)
        {
            _project = project;
        }

        // GET: ProjectController
        public ActionResult Index()
        {
            List<Project> projects = _project.List();
            var data = projects.ToList();
            return View(data);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
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
