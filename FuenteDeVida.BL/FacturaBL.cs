      //Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;
namespace FuenteDeVida.BL
    {
        public class FacturaBL
        {
            public async Task<int> CrearAsync(Factura pFactura)
            {
                return await FacturaDAL.CrearAsync(pFactura);
            }
            public async Task<int> ModificarAsync(Factura pFactura)
            {
                return await FacturaDAL.ModificarAsync(pFactura);
            }

            public async Task<int> EliminarAsync(Factura pFactura)
            {
                return await FacturaDAL.EliminarAsync(pFactura);
            }

            public async Task<Pago> ObtenerPorIdAsync(Factura pFactura)
            {
                return await FacturaDAL.ObtenerPorIdAsync(pFactura);
            }
            public async Task<List<Pago>> ObtenerTodosAsync()
            {
                return await FacturaDAL.ObtenerTodosAsync();
            }
            public async Task<List<Pago>> BuscarAsync(Factura pFactura)
            {
                return await FacturaDAL.BuscarAsync(pFactura);
            }
        }
    }


       