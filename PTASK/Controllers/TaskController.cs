using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Index(bool? isBack, int pg=1)
        {
            string projectId = _cache.Get<string>("ProjectID");
            var result = await _task.GetAllTasks(projectId);
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["isBack"] = isBack;
            TempData["isBack"] = ViewData["isBack"];

            const int pageSize = 9;
            if (pg < 1)
                pg = 1;
            int resCount = result.Count();
            var pager = new Pager(resCount, pg, pageSize);

            int resSkip = (pg - 1) * pageSize;

            var data = result.Skip(resSkip).Take(pager.PageSize).ToList();

            ViewBag.Pager = pager;

            string dataJson = JsonConvert.SerializeObject(data);
            string pagerJson = JsonConvert.SerializeObject(pager);
            TempData["data"] = dataJson;
            TempData["pager"] = pagerJson;

            TempData["pg"] = pg;

            return View(data);
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
        public async Task<ActionResult> Create(PTask task)
        {
            bool isBack = (bool)TempData["isBack"];

            string dataJson = TempData["data"] as string;
            List<PTask> tasks = JsonConvert.DeserializeObject<List<PTask>>(dataJson);

            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 0 && page.TotalItems > 0)
            {
                lastPageElementsCount = 9;
            }

            if (tasks.Count >= 9)
            {
                if (page.EndPage == pg)
                {
                    pg++;
                }
                else
                {
                    if (lastPageElementsCount >= 9)
                    {
                        pg = ++page.EndPage;
                    }
                    else
                    {
                        pg = page.EndPage;
                    }
                }

            }

            var result = await _task.CreateTask(task);

            if (result)
            {
                return RedirectToAction("Index", "Task", new { isBack, pg });
            }
            else
            {
                return BadRequest();
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
