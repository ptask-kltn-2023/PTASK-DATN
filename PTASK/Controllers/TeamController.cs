using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PTASK.Interface;

namespace PTASK.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _team;
        private readonly IMemoryCache _cache;

        public TeamController(ITeamService team, IMemoryCache cache)
        {
            _team = team;
            _cache = cache;
        }

        // GET: MemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MemberController
        public async Task<ActionResult> ListGroups(string projectId)
        {
            var result = await _team.GetAllTeams(projectId);
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = _cache.Get<string>("ProjectID");
            return View(result);
        }
        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
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

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController/Edit/5
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

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberController/Delete/5
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
