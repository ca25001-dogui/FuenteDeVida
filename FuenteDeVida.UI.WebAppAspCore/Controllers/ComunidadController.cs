using FuenteDeVida.BL;
using FuenteDeVida.DAL;

/***************************/
using FuenteDeVida.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaContabilidad.BL;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    public class ComunidadController : Controller
    {
        ComunidadBL comunidadBL = new ComunidadBL();

        // GET: ComunidadController
        public async Task<IActionResult> Index(Comunidad pComunidad = null)
        {
            if (pComunidad == null)
                pComunidad = new Comunidad();
            if (pComunidad.Top_Aux == 0)
                pComunidad.Top_Aux = 10;
            else if (pComunidad.Top_Aux == -1)
                pComunidad.Top_Aux = 0;
            var comunidades = await comunidadBL.BuscarAsync(pComunidad);
            ViewBag.Top = pComunidad.Top_Aux;
            return View(comunidades);
        }

        // GET: ComunidadController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var comunidad = await comunidadBL.ObtenerPorIdAsync(new Comunidad { IdComunidad = id });
            return View(comunidad);
        }

        // GET: ComunidadController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: ComunidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comunidad pComunidad)
        {
            try
            {
                int result = await comunidadBL.CrearAsync(pComunidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pComunidad);
            }
        }

        // GET: ComunidadController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var multa = await comunidadBL.ObtenerPorIdAsync(new Comunidad { IdComunidad = id });

            ViewBag.Error = "";
            return View(multa);
        }

        // POST: ComunidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Comunidad pComunidad)
        {
            try
            {
                int result = await comunidadBL.ModificarAsync(pComunidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View(pComunidad);
            }
        }

        // GET: ComunidadController/Delete/5
        public async Task<IActionResult> Delete(Comunidad pComunidad)
        {
            var comunidad = await comunidadBL.ObtenerPorIdAsync(pComunidad);
            return View(comunidad);
        }

        // POST: ComunidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Comunidad pComunidad)
        {
            try
            {
                int result = await comunidadBL.EliminarAsync(pComunidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pComunidad);
            }
        }
    }
}
