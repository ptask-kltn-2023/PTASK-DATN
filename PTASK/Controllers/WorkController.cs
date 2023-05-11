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
        public async Task<IActionResult> Index(string name, bool? isBack, int pg = 1)
        {
            List<Work> result;
            string projectId = _cache.Get<string>("ProjectID");
            if(name == null || name == "")
            {
                result = await _work.GetAllWorkByIdProject(projectId);
            }
            else
            {
                result = await _work.GetWorksByName(name);
                _cache.Set("isSearch", true);
            }
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            bool isBackGetName;
            bool isBackExists = _cache.TryGetValue("isBack", out isBackGetName);

            if (isBackExists)
            {
                // Lần đầu chạy hoặc không tồn tại trong cache
                ViewData["isBack"] = _cache.Get<bool>("isBack");
            }
            else
            {
                ViewData["isBack"] = isBack;
                _cache.Set("isBack", isBack);
            }

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
        public ActionResult Edit(string workId)
        {

            return PartialView("DetailWork");
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
        public async Task<ActionResult> DeleteWork(string workId)
        {
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

            var result = await _work.DeleteWork(workId);

            if (result)
            {
                return RedirectToAction("Index", "Work", new { isBack, pg });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string createId, string workId)
        {
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

            var result = await _work.ChangeStatus(createId, workId);

            if (result)
            {
                return RedirectToAction("Index", "Work", new { isBack, pg });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
