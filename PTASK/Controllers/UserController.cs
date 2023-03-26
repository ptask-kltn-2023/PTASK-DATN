using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
        {
            _user = user;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/GetUserByEmial/abc@gmail.com
        [HttpGet]
        public ActionResult GetUserByEmail(string email)
        {
            var result = _user.GetUserByEmail(email);
            ViewData["User"]= result;
            return PartialView("~/Views/Project/AddProject.cshtml", new Project());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
