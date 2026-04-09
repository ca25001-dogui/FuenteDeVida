using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using FuenteDeVida.EN;

namespace FuenteDeVida.DAL
{
    public class FacturaDAL
    {

        public static async Task<int> CrearAsync(Factura pFactura)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                dbContexto.Add(pFactura);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Factura pFactura)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                var factura = await dbContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);

                factura.FechaEmision = pFactura.FechaEmision;
                factura.Total = pFactura.Total;
                factura.IdUsuario = pFactura.IdUsuario;
                factura.IdComunidad = pFactura.IdComunidad;

                dbContexto.Update(factura);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Factura pFactura)
        {
            int result = 0;
            using (var dbContexto = new BDContexto())
            {
                var factura = await dbContexto.Factura.FirstOrDefaultAsync(a => a.IdFactura == pFactura.IdFactura);
                dbContexto.Remove(factura);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Factura> ObtenerPorIdAsync(Factura pFactura)
        {
            var factura = new Factura();
            using (var dbContexto = new BDContexto())
            {
                factura = await dbContexto.Factura
                    .Include(f => f.Usuario)
                    .Include(f => f.Comunidad)
                    .FirstOrDefaultAsync(b => b.IdFactura == pFactura.IdFactura);
            }
            return factura;
        }

        public static async Task<List<Factura>> ObtenerTodosAsync()
        {
            var facturas = new List<Factura>();
            using (var dbContexto = new BDContexto())
            {
                facturas = await dbContexto.Factura
                    .Include(f => f.Usuario)
                    .Include(f => f.Comunidad)
                    .ToListAsync();
            }
            return facturas;
        }

        internal static IQueryable<Factura> QuerySelect(IQueryable<Factura> pQuery, Factura pFactura)
        {
            if (pFactura.IdFactura > 0)
                pQuery = pQuery.Where(s => s.IdFactura == pFactura.IdFactura);

            if (pFactura.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pFactura.IdUsuario);

            if (pFactura.IdComunidad > 0)
                pQuery = pQuery.Where(s => s.IdComunidad == pFactura.IdComunidad);
           
            if (pFactura.FechaEmision != DateTime.MinValue)
                pQuery = pQuery.Where(s => s.FechaEmision.Date == pFactura.FechaEmision.Date);

            if (pFactura.Total > 0)
                pQuery = pQuery.Where(s => s.Total == pFactura.Total);

            pQuery = pQuery.OrderByDescending(s => s.IdFactura).AsQueryable();

            if (pFactura.Top_Aux > 0)
                pQuery = pQuery.Take(pFactura.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Factura>> BuscarAsync(Factura pFactura)
        {
            var facturas = new List<Factura>();
            using (var db = new BDContexto())
            {
                var query = db.Factura.AsQueryable();
                if (pFactura.FechaEmision != DateTime.MinValue)
                {
                    query = query.Where(f => f.FechaEmision.Date == pFactura.FechaEmision.Date);
                }
                if (pFactura.Total > 0)
                {
                    query = query.Where(f => f.Total == pFactura.Total);
                }
                if (pFactura.Top_Aux > 0)
                {
                    query = query.Take(pFactura.Top_Aux);
                }
                return await query.ToListAsync();
            }
        }
    }
}