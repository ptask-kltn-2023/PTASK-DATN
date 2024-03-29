﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _team;
        private IMemoryCache _cache;
        public TeamController(ITeamService team, IMemoryCache cache)
        {
            _team = team;
            _cache = cache;
        }

        // GET: MemberController
        public async Task<ActionResult> ListMembers(string searchName, bool? isBack, int pg=1)
        {
            string projectId = _cache.Get<string>("ProjectID");
            List<Member> result;
            if (searchName == null || searchName == "")
            {
                result = await _team.GetAllMembers(projectId);
            }
            else
            {
                result = await _team.GetMembersByName(searchName);
                _cache.Set("isSearch", true);
            }

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
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = _cache.Get<string>("ProjectID");

            return View(data);
        }

        // GET: MemberController
        public async Task<ActionResult> ListGroups(string searchName, int pg=1)
        {
            string projectId = _cache.Get<string>("ProjectID");
            List<Team> result;
            if (searchName == null || searchName == "")
            {
                result = await _team.GetAllTeams(projectId);
            }
            else
            {
                result = await _team.GetTeamsByName(searchName);
                _cache.Set("isSearch", true);
            }

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
            ViewData["TitleProject"] = _cache.Get<string>("TitleProject");
            ViewData["ProjectID"] = _cache.Get<string>("ProjectID");
         
            return View(data);
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam(TeamCreate team, string _idUpdate)
        {
            string projectId = _cache.Get<string>("ProjectID");

            string dataJson = TempData["data"] as string;
            List<Team> teams = JsonConvert.DeserializeObject<List<Team>>(dataJson);

            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 0 && page.TotalItems > 0)
            {
                lastPageElementsCount = 9;
            }

            if (teams.Count >= 9) 
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
            ViewData["isBack"] = false;
            bool result;
            if (_idUpdate != null)
            {
                result = await _team.UpdateTeam(team, _idUpdate);
            }
            else
            {
                result = await _team.CreateTeam(team, projectId);
            }


            if (result)
            {
               
                return RedirectToAction("ListGroups", "Team",pg);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMember(Member member, string teamId)
        {
            bool isBack = (bool)TempData["isBack"];

            string dataJson = TempData["data"] as string;
            List<Member> members = JsonConvert.DeserializeObject<List<Member>>(dataJson);

            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 0 && page.TotalItems > 0)
            {
                lastPageElementsCount = 9;
            }

            if (members.Count >= 9)
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

            var result = await _team.AddMember(member, teamId);

            if (result)
            {
                return RedirectToAction("ListMembers", "Team", new { isBack, pg });
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: TeamController/DeleteTeam/5
        [HttpPost]
        public async Task<IActionResult> DeleteTeam(string teamId)
        {
            bool isBack = (bool)TempData["isBack"];

            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 1)
            {
                pg--;
            }

            var result = await _team.DeleteTeamInProject(teamId);

            if (result)
            {
                return RedirectToAction("ListGroups", "Team", new { isBack, pg });
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteMember(string memberId)
        {
            string pagerJson = TempData["pager"] as string;
            Pager page = JsonConvert.DeserializeObject<Pager>(pagerJson);
            int pg = (int)TempData["pg"];

            int lastPageElementsCount = page.TotalItems % 9;
            if (lastPageElementsCount == 1)
            {
                pg--;
            }

            var result = await _team.DeleteMemberInProject(memberId);

            if (result)
            {
                return RedirectToAction("ListMembers", "Team", pg);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
