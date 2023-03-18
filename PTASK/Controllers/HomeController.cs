using Microsoft.AspNetCore.Mvc;
using PTASK.Models;
using System.Diagnostics;

namespace PTASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
            {
                var token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                if (token == null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Project");
                }
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}