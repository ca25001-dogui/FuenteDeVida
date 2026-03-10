//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;
namespace FuenteDeVida.BL
{
    public class PagoBL
    {
        public async Task<int> CrearAsync(Pago pPago)
        {
            return await PagoDAL.CrearAsync(pPago);
        }
        public async Task<int> ModificarAsync(Pago pPago)
        {
            return await PagoDAL.ModificarAsync(pPago);
        }

        public async Task<int> EliminarAsync(Pago pPago)
        {
            return await PagoDAL.EliminarAsync(pPago);
        }

        public async Task<Pago> ObtenerPorIdAsync(Pago pPago)
        {
            return await PagoDAL.ObtenerPorIdAsync(pPago);
        }
        public async Task<List<Pago>> ObtenerTodosAsync()
        {
            return await PagoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Pago>> BuscarAsync(Pago pPago)
        {
            return await PagoDAL.BuscarAsync(pPago);
        }
    }
}


