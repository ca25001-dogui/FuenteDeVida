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
    public class PagoDAL
    {
        public static async Task<int> CrearAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pPago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == pPago.IdPago);
                pago.MontoTotal = pPago.MontoTotal;
                bdContexto.Update(pago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == pPago.IdPago);
                bdContexto.Pago.Remove(pago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Pago> ObtenerPorIdAsync(Pago pPago)
        {
            var pago = new Pago();
            using (var bdContexto = new BDContexto())
            {
                pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == pPago.IdPago);
            }
            return pago;
        }
        public static async Task<List<Pago>> ObtenerTodosAsync()
        {
            var pagos = new List<Pago>();
            using (var bdContexto = new BDContexto())
            {
                pagos = await bdContexto.Pago.ToListAsync();
            }
            return pagos;
        }
        internal static IQueryable<Pago> QuerySelect(IQueryable<Pago> pQuery
           , Pago pPago)
        {
            if (pPago.IdPago > 0)
                pQuery = pQuery.Where(s => s.IdPago == pPago.IdPago);
            if (pPago.MontoTotal > 0)
                pQuery = pQuery.Where(s => s.MontoTotal == pPago.MontoTotal);
            pQuery = pQuery.OrderByDescending(s => s.IdPago).AsQueryable();
            if (pPago.Top_Aux > 0)
                pQuery = pQuery.Take(pPago.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Pago>> BuscarAsync(Pago pPago)
        {
            var pagos = new List<Pago>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Pago.AsQueryable();
                select = QuerySelect(select, pPago);
                pagos = await select.ToListAsync();
            }
            return pagos;
        }
    }
}
