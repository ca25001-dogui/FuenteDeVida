using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/***************************/
using FuenteDeVida.EN;
using FuenteDeVida.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]


    public class CuotaController : Controller
    {
        CuotaBL cuotaBL = new CuotaBL();

        // GET: CuotaController
        public async Task<IActionResult> Index(Cuota pCuota = null)
        {
            if (pCuota == null)
                pCuota = new Cuota();
            if (pCuota.Top_Aux == 0)
                pCuota.Top_Aux = 10;
            else if (pCuota.Top_Aux == -1)
                pCuota.Top_Aux = 0;

            var cuotas = await cuotaBL.BuscarAsync(pCuota);
            ViewBag.Top = pCuota.Top_Aux;
            return View(cuotas);
        }

        // GET: CuotaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cuota = await cuotaBL.ObtenerPorIdAsync(new Cuota { IdCuota = id });
            return View(cuota);
        }

        // GET: CuotaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: CuotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cuota pCuota)
        {
            try
            {
                int result = await cuotaBL.CrearAsync(pCuota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCuota);
            }
        }

        // GET: CuotaController/Edit/5
        public async Task<IActionResult> Edit(Cuota pCuota)
        {
            var cuota = await cuotaBL.ObtenerPorIdAsync(pCuota);
            ViewBag.Error = "";
            return View(cuota);
        }

        // POST: CuotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cuota pCuota)
        {
            try
            {
                int result = await cuotaBL.ModificarAsync(pCuota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCuota);
            }
        }

        // GET: CuotaController/Delete/5
        public async Task<IActionResult> Delete(Cuota pCuota)
        {
            var cuota = await cuotaBL.ObtenerPorIdAsync(pCuota);
            return View(cuota);
        }

        // POST: CuotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Cuota pCuota)
        {
            try
            {
                int result = await cuotaBL.EliminarAsync(pCuota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCuota);
            }
        }
    }
}
