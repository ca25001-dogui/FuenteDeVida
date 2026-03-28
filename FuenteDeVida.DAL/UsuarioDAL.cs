using FuenteDeVida.DAL;
using FuenteDeVida.EN;
//****************************
// Referencias del proyecto
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.DAL
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(Usuario pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUsuario.Clave));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Clave = strEncriptar;

            }
        }
        private static async Task<bool> ExisteCorreo(Usuario pUsuario, BDContexto pDbContexto)
        {
            bool result = false;
            var LoginUsuarioExiste = await pDbContexto.Usuario.FirstOrDefaultAsync(s => s.Nombre == pUsuario.Nombre && s.IdUsuario != pUsuario.IdUsuario);
            if (LoginUsuarioExiste != null && LoginUsuarioExiste.IdUsuario > 0 && LoginUsuarioExiste.Nombre == pUsuario.Nombre)
                result = true;
            return result;
        }



        #region CRUD

        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeLogin = await ExisteCorreo(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    EncriptarMD5(pUsuario);
                    bdContexto.Add(pUsuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Correo ya existe");
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeCorreo = await ExisteCorreo(pUsuario, bdContexto);
                if (existeCorreo == false)
                {
                    var usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
                    usuario.IdRol = pUsuario.IdRol;
                    usuario.Nombre = pUsuario.Nombre;
                    usuario.Apellido = pUsuario.Apellido;
                    usuario.Correo = pUsuario.Correo;
                    usuario.Clave = pUsuario.Clave;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
                bdContexto.Usuario.Remove(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContexto = new BDContexto())
            {
                usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
            }
            return usuario;
        }
        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                usuarios = await bdContexto.Usuario.ToListAsync();
            }
            return usuarios;
        }
        internal static IQueryable<Usuario> QuerySelect(IQueryable<Usuario> pQuery
           , Usuario pUsuario)
        {
            if (pUsuario.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pUsuario.IdUsuario);

            if (pUsuario.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUsuario.IdRol);

            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));

            if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pUsuario.Apellido));

            if (!string.IsNullOrWhiteSpace(pUsuario.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pUsuario.Correo));

            if (!string.IsNullOrWhiteSpace(pUsuario.Clave))
                pQuery = pQuery.Where(s => s.Clave.Contains(pUsuario.Clave));

            // Ordenar por IdUsuario 
            pQuery = pQuery.OrderByDescending(s => s.IdUsuario).AsQueryable();


            if (pUsuario.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario);
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        #endregion
        public static async Task<List<Usuario>> BuscarIncluirRolesAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        public static async Task<Usuario> CorreoAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContexto = new BDContexto())
            {
                EncriptarMD5(pUsuario);
                usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s =>
                    s.Correo == pUsuario.Correo &&
                    s.Clave == pUsuario.Clave
                );
            }
            return usuario;
        }

        public static async Task<int> ClaveAsync(Usuario pUsuario, string pClaveAnt)
        {
            int result = 0;
            var usuarioClaveAnt = new Usuario { Clave = pClaveAnt };
            EncriptarMD5(usuarioClaveAnt);

            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.Usuario
                    .FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);

                if (usuarioClaveAnt.Clave == usuario.Clave)
                {
                    EncriptarMD5(pUsuario);
                    usuario.Clave = pUsuario.Clave;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("La clave actual es incorrecta");
            }
            return result;
        }

    }
}





