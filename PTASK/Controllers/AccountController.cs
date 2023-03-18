using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTASK.Interface;
using PTASK.Models;
using System.Net.Http;
using System.Reflection;

namespace PTASK.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _auth;
        public AccountController(IAuthService auth)
        {
            _auth = auth;
        }
        // GET: LoginController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var result = await _auth.Login(model);
          
            if (result != null)
            {
                return RedirectToAction("Index", "Project");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không thành công");
                return View(model);
            }
        } 
          
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: LoginController
        public ActionResult Register()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
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

        // GET: LoginController
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(IFormCollection collection)
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
