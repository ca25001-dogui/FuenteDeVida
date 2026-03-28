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
    public class MultaDAL
    {
        public static async Task<int> CrearAsync(Multa pMulta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMulta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Multa pMulta)
        {
            {
                int result = 0;
                using (var bdContexto = new BDContexto())
                {
                    var multa = await bdContexto.Multa
                        .FirstOrDefaultAsync(s => s.IdMulta == pMulta.IdMulta);

                    if (multa != null)
                    {
                        multa.Monto = pMulta.Monto;
                        multa.FechaVencimiento = pMulta.FechaVencimiento;
                        multa.IdComunidad = pMulta.IdComunidad;

                        bdContexto.Update(multa);
                        result = await bdContexto.SaveChangesAsync();
                    }
                }
                return result;
            }
        }
        public static async Task<int> EliminarAsync(Multa pMulta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var multa = await bdContexto.Multa.FirstOrDefaultAsync(s => s.IdMulta == pMulta.IdMulta);
                if (multa != null)
                {
                    bdContexto.Multa.Remove(multa);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                {
                    result = 0; // No encontró la multa
                }
            }
            return result;
        }
        public static async Task<Multa> ObtenerPorIdAsync(Multa pMulta)
        {
            var multa = new Multa();
            using (var bdContexto = new BDContexto())
            {
                multa = await bdContexto.Multa.FirstOrDefaultAsync(s => s.IdMulta == pMulta.IdMulta);
            }
            return multa;
        }
        public static async Task<List<Multa>> ObtenerTodosAsync()
        {
            var multas = new List<Multa>();
            using (var bdContexto = new BDContexto())
            {
                multas = await bdContexto.Multa.ToListAsync();
            }
            return multas;
        }
        internal static IQueryable<Multa> QuerySelect(IQueryable<Multa> pQuery
           , Multa pMulta)
        {
            if (pMulta.IdMulta > 0)
                pQuery = pQuery.Where(s => s.IdMulta == pMulta.IdMulta);
            if (pMulta.Monto > 0)
                pQuery = pQuery.Where(s => s.Monto == pMulta.Monto);
            pQuery = pQuery.OrderByDescending(s => s.IdMulta).AsQueryable();
            if (pMulta.Top_Aux > 0)
                pQuery = pQuery.Take(pMulta.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Multa>> BuscarAsync(Multa pMulta)
        {
            var multas = new List<Multa>();
            using (var dbContexto = new BDContexto())
            {
                var select = dbContexto.Multa.AsQueryable();
                select = QuerySelect(select, pMulta);
                multas = await select.ToListAsync();
            }
            return multas;
        }
    }
}
