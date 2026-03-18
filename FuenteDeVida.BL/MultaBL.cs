//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;

namespace FuenteDeVida.BL
{
    public class MultaBL
    {
        public async Task<int> CrearAsync(Multa pMulta)
        {
            return await MultaDAL.CrearAsync(pMulta);
        }
        public async Task<int> Modificar(Multa pMulta)
        {
            return await MultaDAL.ModificarAsync(pMulta);
        }

        public async Task<int> EliminarAsync(Multa pMulta)
        {
            return await MultaDAL.EliminarAsync(pMulta);
        }

        public async Task<Multa> ObtenerPorIdAsync(Multa pMulta)
        {
            return await MultaDAL.ObtenerPorIdAsync(pMulta);
        }
        public async Task<List<Multa>> ObtenerTodosAsync()
        {
            return await MultaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Multa>> BuscarAsync(Multa pMulta)
        {
            return await MultaDAL.BuscarAsync(pMulta);
        }

        public async Task<int> ModificarAsync(Multa pMulta)
        {
            throw new NotImplementedException();
        }
    }
}
