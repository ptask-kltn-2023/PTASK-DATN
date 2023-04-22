using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using NuGet.Common;
using PTASK.Interface;
using PTASK.Models;
using System.Net.Http;
using System.Reflection;

namespace PTASK.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _auth;
        private readonly IJwtService _jwtService;

        public AccountController(IAuthService auth, IJwtService jwtService)
        {
            _auth = auth;
            _jwtService = jwtService;
        }
        // GET: LoginController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        public async Task<IActionResult> Login(Auth model)
        {
            var result = await _auth.Login(model);

            if (result != null)
            {
                var payload = _jwtService.DecodeToken(result);

                var userJson = payload["user"].ToString();
                dynamic user = JsonConvert.DeserializeObject<dynamic>(userJson);
                string idUser = user._id;

                var cache = HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
                cache.Set("UserId", idUser);

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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        public async Task<IActionResult> Register(Auth model)
        {
            var result = await _auth.Register(model);

            if (result != null)
            {
                return RedirectToAction("Index", "Project");
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
                return View(model);
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
