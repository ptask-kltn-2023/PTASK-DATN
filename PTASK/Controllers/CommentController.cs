using Microsoft.AspNetCore.Mvc;

namespace PTASK.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
