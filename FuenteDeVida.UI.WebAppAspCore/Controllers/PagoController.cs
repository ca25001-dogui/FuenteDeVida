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
    public class PagoController : Controller
    {
        PagoBL pagoBL = new PagoBL();

        // GET: PagoController
        public async Task<IActionResult> Index(Pago pPago = null)
        {
            if (pPago == null)
                pPago = new Pago();
            if (pPago.Top_Aux == 0)
                pPago.Top_Aux = 10;
            else if (pPago.Top_Aux == -1)
                pPago.Top_Aux = 0;
            var pagos = await pagoBL.BuscarAsync(pPago);
            ViewBag.Top = pPago.Top_Aux;
            return View(pagos);
        }

        // GET: PagoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pago = await pagoBL.ObtenerPorIdAsync(new Pago { IdPago = id });
            return View(pago);
        }

        // GET: PagoController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pago pPago)
        {
            try
            {
                int result = await pagoBL.CrearAsync(pPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View(pPago);
            }
        }

        // GET: PagoController/Edit/5
        public async Task<IActionResult> Edit(Pago pPago)
        {
            var pago = await pagoBL.ObtenerPorIdAsync(pPago);
            ViewBag.Error = "";
            return View(pago);
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pago pPago)
        {
            try
            {
                int result = await pagoBL.ModificarAsync(pPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View(pPago);
            }
        }

        // GET: PagoController/Delete/5
        public async Task<IActionResult> Delete(Pago pPago)
        {
            var pago = await pagoBL.ObtenerPorIdAsync(pPago);
            return View(pago);
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Pago pPago)
        {
            try
            {
                int result = await pagoBL.EliminarAsync(pPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View(pPago);
            }
        }
    }
}
