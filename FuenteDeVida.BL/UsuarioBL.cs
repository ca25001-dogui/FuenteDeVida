namespace FuenteDeVida.BL
//Referencias
using System.Security.Cryptography;
// Referencias del proyecto
using FuenteDeVida.DAL;
using FuenteDeVida.EN;
using System.Collections.Generic;
using System.Text;

namespace FuenteDeVida.BL
{
    public class RolBL
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
        
    }
}