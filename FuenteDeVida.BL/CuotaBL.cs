//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;

namespace FuenteDeVida.BL
{
    public class CuotaBL
    {
        public async Task<int> CrearAsync(Cuota pCuota)
        {
            return await CuotaDAL.CrearAsync(pCuota);
        }
        public async Task<int> ModificarAsync(Cuota pCuota)
        {
            return await CuotaDAL.ModificarAsync(pCuota);
        }

        public async Task<int> EliminarAsync(Cuota pCuota)
        {
            return await CuotaDAL.EliminarAsync(pRol);
        }

        public async Task<Rol> ObtenerPorIdAsync(Cuota pCuota)
        {
            return await CuotaDAL.ObtenerPorIdAsync(pCuota);
        }
        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await CuotaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Rol>> BuscarAsync(Cuota pCuota)
        {
            return await CuotaDAL.BuscarAsync(pCuota);
        }
    }

}
