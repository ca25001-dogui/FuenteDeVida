//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;

namespace SistemaContabilidad.BL
{
    public class ComunidadBL
    {
        public async Task<int> CrearAsync(Comunidad pComunidad)
        {
            return await ComunidadDAL.CrearAsync(pComunidad);
        }
        public async Task<int> ModificarAsync(Comunidad pComunidad)
        {
            return await ComunidadDAL.ModificarAsync(pComunidad);
        }

        public async Task<int> EliminarAsync(Comunidad pComunidad)
        {
            return await ComunidadDAL.EliminarAsync(pComunidad);
        }

        public async Task<Comunidad> ObtenerPorIdAsync(Comunidad pComunidad)
        {
            return await ComunidadDAL.ObtenerPorIdAsync(pComunidad);
        }
        public async Task<List<Comunidad>> ObtenerTodosAsync()
        {
            return await ComunidadDAL.ObtenerTodosAsync();
        }
        public async Task<List<Comunidad>> BuscarAsync(Comunidad pComunidad)
        {
            return await ComunidadDAL.BuscarAsync(pComunidad);
        }
    }
}

