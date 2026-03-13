using FuenteDeVida.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.DAL
{
    public class ComunidadDAL
    {
        public static async Task<int> CrearAsync(Comunidad pComunidad)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pComunidad);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Comunidad pComunidad)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var comunidad = await bdContexto.Comunidad.FirstOrDefaultAsync(s => s.IdComunidad == pComunidad.IdComunidad);
                comunidad.Monto = pComunidad.Monto;
                bdContexto.Update(comunidad);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Comunidad pComunidad)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var comunidad = await bdContexto.Comunidad.FirstOrDefaultAsync(s => s.IdComunidad == pComunidad.IdComunidad);
                bdContexto.Comunidad.Remove(comunidad);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Comunidad> ObtenerPorIdAsync(Comunidad pComunidad)
        {
            var comunidad = new Comunidad();
            using (var bdContexto = new BDContexto())
            {
                comunidad = await bdContexto.Comunidad.FirstOrDefaultAsync(s => s.IdComunidad == pComunidad.IdComunidad);
            }
            return comunidad;
        }
        public static async Task<List<Comunidad>> ObtenerTodosAsync()
        {
            var comunidades = new List<Comunidad>();
            using (var bdContexto = new BDContexto())
            {
                comunidades = await bdContexto.Comunidad.ToListAsync();
            }
            return comunidades;
        }
        internal static IQueryable<Comunidad> QuerySelect(IQueryable<Comunidad> pQuery
           , Comunidad pComunidad)
        {
            if (pComunidad.IdComunidad > 0)
                pQuery = pQuery.Where(s => s.IdComunidad == pComunidad.IdComunidad);
            if (!string.IsNullOrWhiteSpace(pComunidad.))
                pQuery = pQuery.Where(s => s.TipoServicio.Contains(pComunidad.TipoServicio));
            pQuery = pQuery.OrderByDescending(s => s.IdComunidad).AsQueryable();
            if (pComunidad.Top_Aux > 0)
                pQuery = pQuery.Take(pComunidad.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Comunidad>> BuscarAsync(Comunidad pComunidad)
        {
            var comunidades = new List<Comunidad>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Comunidad.AsQueryable();
                select = QuerySelect(select, pComunidad);
                comunidades = await select.ToListAsync();
            }
            return comunidades;
        }
    }
}
