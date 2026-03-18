using FuenteDeVida.BL;
using FuenteDeVida.DAL;
/***************************/
using FuenteDeVida.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MultaController : Controller
    {
        MultaBL multaBL = new MultaBL();

        // GET: MultaController
        public async Task<IActionResult> Index(Multa pMulta = null)
        {
            if (pMulta == null)
                pMulta = new Multa();
            if (pMulta.Top_Aux == 0)
                pMulta.Top_Aux = 10;
            else if (pMulta.Top_Aux == -1)
                pMulta.Top_Aux = 0;
            var multas = await multaBL.BuscarAsync(pMulta);
            ViewBag.Top = pMulta.Top_Aux;
            return View(multas);
        }
        // GET: MultaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var multa = await multaBL.ObtenerPorIdAsync(new Multa { IdMulta = id });
            return View(multa);
        }

        // GET: MultaController/Create
        public IActionResult Create()
        {
                ViewBag.Error = "";
                return View();
        }

        // POST: MultaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Multa pMulta)
        {
            try
            {
                int result = await multaBL.CrearAsync(pMulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMulta);
            }
        }

        // GET: MultaController/Edit/5
        public async Task<IActionResult> Edit(Multa pMulta)
        {
            var multa = await multaBL.ObtenerPorIdAsync(pMulta);
            ViewBag.Error = "";
            return View(multa);
        }

        // POST: MultaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Multa pMulta)
        {
            try
            {
                int result = await multaBL.ModificarAsync(pMulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMulta);
            }
        }

        // GET: MultaController/Delete/5
        public async Task<IActionResult> Delete(Multa pMulta)
        {
            var multa = await multaBL.ObtenerPorIdAsync(pMulta);
            return View(multa);
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Multa pMulta)
        {
            try
            {
                int result = await multaBL.EliminarAsync(pMulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMulta);
            }
        }
    }
}
