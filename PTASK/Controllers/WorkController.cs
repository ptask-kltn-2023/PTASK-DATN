using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService _work;
        private readonly IMemoryCache _cache;

        public WorkController(IWorkService work, IMemoryCache cache)
        {
            _work = work;
            _cache = cache;
        }
        // GET: WorkController
        public async Task<IActionResult> Index(string projectId)
        {
            var result = await _work.GetAllWorkByIdProject(projectId);
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = _cache.Get<string>("ProjectID");

            return View(result);
        }

        // GET: WorkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkController/Create
        [HttpGet]
        public ActionResult AddWork(Work work)
        {
            return PartialView("_AddWork", work);
        }

        // POST: WorkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Work work)
        {
            return View();
            //var result = await _work.CreateWork(work);

            //if (result)
            //{
            //    return RedirectToAction("Index", "Project");
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }

        // GET: WorkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkController/Edit/5
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

        // GET: WorkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkController/Delete/5
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
