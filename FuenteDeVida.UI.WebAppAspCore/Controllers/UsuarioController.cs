using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/********************************/
using FuenteDeVida.EN;
using FuenteDeVida.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FuenteDeVida.UI.WebAppAspCore.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioBL usuarioBL = new UsuarioBL();
        RolBL rolBL = new RolBL();
        // GET: UsuarioController
        public async Task<IActionResult> Index(Usuario pUsuario = null)
        {
            if (pUsuario == null)
                pUsuario = new Usuario();
            if (pUsuario.Top_Aux == 0)
                pUsuario.Top_Aux = 10;
            else if (pUsuario.Top_Aux == -1)
                pUsuario.Top_Aux = 0;
            var taskBuscar = usuarioBL.BuscarAsync(pUsuario);
            var taskObtenerTodosRoles = rolBL.ObtenerTodosAsync();
            var usuarios = await taskBuscar;
            ViewBag.Top = pUsuario.Top_Aux;
            ViewBag.Roles = await taskObtenerTodosRoles;
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { IdRol = id });
            usuario.Rol = await rolBL.ObtenerPorIdAsync(new Rol { IdRol = usuario.IdRol });
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.CrearAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(Usuario pUsuario)
        {
            var taskObtenerPorId = usuarioBL.ObtenerPorIdAsync(pUsuario);
            var taskObtenerTodosRoles = rolBL.ObtenerTodosAsync();
            var usuario = await taskObtenerPorId;
            ViewBag.Roles = await taskObtenerTodosRoles;
            ViewBag.Error = "";
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.ModificarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(Usuario pUsuario)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(pUsuario);
            usuario.Rol = await rolBL.ObtenerPorIdAsync(new Rol { IdRol = usuario.IdRol });
            ViewBag.Error = "";
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.EliminarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var usuario = await usuarioBL.ObtenerPorIdAsync(pUsuario);
                if (usuario == null)
                    usuario = new Usuario();
                if (usuario.IdRol > 0)
                    usuario.Rol = await rolBL.ObtenerPorIdAsync(new Rol { IdRol = usuario.IdRol });
                return View(usuario);
            }
        }
        // GET: UsuarioController/Create
        public ActionResult Correo()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       

        // GET: UsuarioController/Create
        public ActionResult Clave()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clave(IFormCollection collection)
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
