//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.EN;
using FuenteDeVida.DAL;
using System.Net.Sockets;


namespace FuenteDeVida.BL
{
    public class UsuarioBL
    {
        private static string CifrarSha256(string pTexto)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pTexto); // Codificar el texto a bytes
                                                              // Crear y usar SHA256 de forma segura
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(bytes);
                // Convertir hash a cadena hexadecimal
                StringBuilder hashString = new StringBuilder();
                foreach (byte x in hash)
                {
                    hashString.AppendFormat("{0:x2}", x);
                }
                return hashString.ToString();
            }
        }

        public int Guardar(Usuario pUsuario)
        {
            pUsuario.Clave = CifrarSha256(pUsuario.Clave); //Encriptar la Clave
            return UsuarioDAL.Guardar(pUsuario);
        }

        public async Task<int> ModificarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }

        public async Task<int> EliminarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }

        public async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ObtenerPorIdAsync(pUsuario);
        }
        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }
        public async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }
    }
}