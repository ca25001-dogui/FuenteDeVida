using FuenteDeVida.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using FuenteDeVida.EN;

namespace FuenteDeVida.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                rol.NombreRol = pRol.NombreRol;
                bdContexto.Update(rol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                if (rol != null)
                {
                    bdContexto.Rol.Remove(rol);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }
        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            var rol = new Rol();
            using (var bdContexto = new BDContexto())
            {
                rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
            }
            return rol;
        }
        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            var roles = new List<Rol>();
            using (var bdContexto = new BDContexto())
            {
                roles = await bdContexto.Rol.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery
           , Rol pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);

            pQuery = pQuery.Where(s => s.NombreRol == pRol.NombreRol);
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            using (var db = new BDContexto())
            {
                var query = db.Rol.AsQueryable();

                //Solo filtra si tiene un valor
                if (!string.IsNullOrEmpty(pRol.NombreRol))
                    query = query.Where(r => r.NombreRol.Contains(pRol.NombreRol));

                if (pRol.Top_Aux > 0)
                    query = query.Take(pRol.Top_Aux);

                return await query.ToListAsync();
            }
        }
    }
}
