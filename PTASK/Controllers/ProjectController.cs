﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTASK.Interface;
using PTASK.Models;
using System.Reflection;

namespace PTASK.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _project;

        public ProjectController(IProjectService project)
        {
            _project = project;
        }

        // GET: ProjectController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _project.List();
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
