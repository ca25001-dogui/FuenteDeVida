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
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class FacturaController : Controller
    {
        FacturaBL facturaBL = new FacturaBL();
        UsuarioBL usuarioBL = new UsuarioBL();
        ComunidadBL comunidadBL = new ComunidadBL();

        // GET: FacturaController
        public async Task<IActionResult> Index(Factura pFactura = null)
        {
            if (pFactura == null)
                pFactura = new Factura();
            if (pFactura.Top_Aux == 0)
                pFactura.Top_Aux = 10;
            else if (pFactura.Top_Aux == -1)
                pFactura.Top_Aux = 0;

            var facturas = await facturaBL.BuscarAsync(pFactura);
            ViewBag.Top = pFactura.Top_Aux;
            return View(facturas);
        }

        // GET: FacturaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var factura = await facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            return View(factura);
        }

        // GET: FacturaController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Comunidades = await comunidadBL.ObtenerTodosAsync();

            ViewBag.Error = "";
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Factura pFactura)
        {
            try
            {
                // 🔥 Validación básica
                if (pFactura.IdUsuario == 0 || pFactura.IdComunidad == 0)
                    throw new Exception("Debe seleccionar Usuario y Comunidad");

                // 🔥 Fecha automática (por si no la mandan)
                if (pFactura.FechaEmision == DateTime.MinValue)
                    pFactura.FechaEmision = DateTime.Now;

                int result = await facturaBL.CrearAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();

                // 🔥 MUY IMPORTANTE: volver a llenar combos
                ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
                ViewBag.Comunidades = await comunidadBL.ObtenerTodosAsync();

                return View(pFactura);
            }
        }

        // GET: FacturaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var factura = await facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            ViewBag.Error = "";
            return View(factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Factura pFactura)
        {
            try
            {
                int result = await facturaBL.ModificarAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }

        // GET: FacturaController/Delete/5
        public async Task<IActionResult> Delete(Factura pFactura)
        {
            var factura = await facturaBL.ObtenerPorIdAsync(pFactura);
            return View(factura);
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Factura pFactura)
        {
            try
            {
                int result = await facturaBL.EliminarAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }
    }
}