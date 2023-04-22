using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Index(bool? isBack, int pg = 1)
        {
            string projectId = _cache.Get<string>("ProjectID");
            var result = await _work.GetAllWorkByIdProject(projectId);
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


        // GET: WorkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkCreate work)
        {
            string projectId = _cache.Get<string>("ProjectID");

            bool isBack = (bool)TempData["isBack"];

            string dataJson = TempData["data"] as string;
            List<Work> works = JsonConvert.DeserializeObject<List<Work>>(dataJson);

            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 0 && page.TotalItems > 0)
            {
                lastPageElementsCount = 9;
            }

            if (works.Count >= 9)
            {
                if(page.EndPage == pg)
                {
                    pg++;
                }
                else
                {
                    if(lastPageElementsCount >= 9)
                    {
                        pg = ++page.EndPage;
                    }
                    else
                    {
                        pg = page.EndPage;
                    }
                }
                
            }

            var result = await _work.CreateWork(work, projectId);

            if (result)
            {
                return RedirectToAction("Index", "Work", new {isBack,pg});
            }
            else
            {
                return BadRequest();
            }
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
