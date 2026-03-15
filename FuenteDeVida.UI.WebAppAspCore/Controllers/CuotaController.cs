using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    public class CuotaController : Controller
    {
        // GET: CuotaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CuotaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuotaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuotaController/Create
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

        // GET: CuotaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuotaController/Edit/5
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

        // GET: CuotaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuotaController/Delete/5
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
