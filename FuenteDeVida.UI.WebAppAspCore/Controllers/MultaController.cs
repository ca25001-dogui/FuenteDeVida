using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    public class MultaController : Controller
    {
        // GET: MultaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MultaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MultaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultaController/Create
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

        // GET: MultaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MultaController/Edit/5
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

        // GET: MultaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MultaController/Delete/5
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
