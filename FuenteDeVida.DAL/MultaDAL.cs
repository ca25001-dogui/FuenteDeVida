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
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var multa = await bdContexto.Multa.FirstOrDefaultAsync(s => s.Id == pMulta.Id);
                multa.Monto = pMulta.Monto;
                bdContexto.Update(multa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Multa pMulta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var multa = await bdContexto.Multa.FirstOrDefaultAsync(s => s.Id == pMulta.Id);
                bdContexto.Multa.Remove(multa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Multa> ObtenerPorIdAsync(Multa pMulta)
        {
            var multa = new Multa();
            using (var bdContexto = new BDContexto())
            {
                multa = await bdContexto.Multa.FirstOrDefaultAsync(s => s.Id == pMulta.Id);
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
            if (pMulta.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMulta.Id);//Where Id = 1
            if (!string.IsNullOrWhiteSpace(pMulta.))
                pQuery = pQuery.Where(s => s.Monto.Contains(pMulta.Monto));//Where Nombre like '%A%'
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();//Order by Id Desc
            if (pMulta.Top_Aux > 0)
                pQuery = pQuery.Take(pMulta.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Multa>> BuscarAsync(Multa pMulta)
        {
            var multas = new List<Multa>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Multa.AsQueryable();
                select = QuerySelect(select, pMulta);
                multas = await select.ToListAsync();
            }
            return multas;
        }
    }
}
