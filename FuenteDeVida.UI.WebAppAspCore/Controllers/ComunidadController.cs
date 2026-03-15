using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    public class ComunidadController : Controller
    {
        // GET: ComunidadController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComunidadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComunidadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComunidadController/Create
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

        // GET: ComunidadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComunidadController/Edit/5
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

        // GET: ComunidadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComunidadController/Delete/5
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
