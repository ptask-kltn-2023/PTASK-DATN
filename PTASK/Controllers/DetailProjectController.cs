using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTASK.Controllers
{
    public class DetailProjectController : Controller
    {
        // GET: DetailProjectController
        public IActionResult Index()
        {

            return View();
        }
        // GET: DetailProjectController/ListWorks
        public IActionResult ListWorks()
        {

            return View();
        }

        public IActionResult WorksSuccess()
        {
            return View();
        }

        // GET: DetailProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailProjectController/Create
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

        // GET: DetailProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailProjectController/Edit/5
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

        // GET: DetailProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailProjectController/Delete/5
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
