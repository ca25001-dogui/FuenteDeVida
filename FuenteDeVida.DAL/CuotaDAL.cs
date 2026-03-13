using FuenteDeVida.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.DAL
{
    public class CuotaDAL
    {
        public static async Task<int> CrearAsync(Cuota pCuota)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                dbContexto.Add(pCuota);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Cuota pCuota)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                var cuota = await dbContexto.Cuota.FirstOrDefaultAsync(s => s.IdCuota == pCuota.IdCuota);

                cuota.Monto = pCuota.Monto;
                cuota.TipoServicio = pCuota.TipoServicio;
                cuota.FechaLimite = pCuota.FechaLimite;
                cuota.IdComunidad = pCuota.IdComunidad;

                dbContexto.Update(cuota);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Cuota pCuota)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                var cuota = await dbContexto.Cuota.FirstOrDefaultAsync(a => a.IdCuota == pCuota.IdCuota);
                dbContexto.Remove(cuota);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Cuota> ObtenerPorIdAsync(Cuota pCuota)
        {
            var cuota = new Cuota();
            using (var dbContexto = new BDContexto())
            {
                cuota = await dbContexto.Cuota
                    .Include(c => c.Comunidad)
                    .FirstOrDefaultAsync(b => b.IdCuota == pCuota.IdCuota);
            }
            return cuota;
        }

        public static async Task<List<Cuota>> ObtenerTodosAsync()
        {
            var cuotas = new List<Cuota>();
            using (var dbContexto = new BDContexto())
            {
                cuotas = await dbContexto.Cuota
                    .Include(c => c.Comunidad)
                    .ToListAsync();
            }
            return cuotas;
        }

        internal static IQueryable<Cuota> QuerySelect(IQueryable<Cuota> pQuery, Cuota pCuota)
        {
            if (pCuota.IdCuota > 0)
                pQuery = pQuery.Where(s => s.IdCuota == pCuota.IdCuota);

            if (pCuota.IdComunidad > 0)
                pQuery = pQuery.Where(s => s.IdComunidad == pCuota.IdComunidad);

            if (!string.IsNullOrWhiteSpace(pCuota.TipoServicio))
                pQuery = pQuery.Where(s => s.TipoServicio.Contains(pCuota.TipoServicio));

            pQuery = pQuery.OrderByDescending(s => s.IdCuota).AsQueryable();

            if (pCuota.TopAux > 0)
                pQuery = pQuery.Take(pCuota.TopAux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Cuota>> BuscarAsync(Cuota pCuota)
        {
            var cuotas = new List<Cuota>();
            using (var dbContexto = new BDContexto())
            {
                var select = dbContexto.Cuota.Include(c => c.Comunidad).AsQueryable();
                select = QuerySelect(select, pCuota);
                cuotas = await select.ToListAsync();
            }
            return cuotas;
        }
    }
}


