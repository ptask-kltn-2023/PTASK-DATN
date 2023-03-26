using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _task;
        private readonly IMemoryCache _cache;

        public TaskController(ITaskService task, IMemoryCache cache)
        {
            _task = task;
            _cache = cache;
        }
        // GET: TaskController
        public async Task<IActionResult> Index(string projectId)
        {
            var result = await _task.GetAllTasks(projectId);
            //Lấy dữ liệu từ bộ nhớ tạm gán vào View Data
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = _cache.Get<string>("ProjectID");

            return View(result);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
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

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskController/Edit/5
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

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskController/Delete/5
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
