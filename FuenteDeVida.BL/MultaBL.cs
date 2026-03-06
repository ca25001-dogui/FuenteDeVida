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
        public int Guardar(MultaBL pMulta)
        {
            return MultaDAL.Guardar(pMulta);
        }
        public int Modificar(MultaBL pMulta)
        {
            return MultaDAL.Modificar(pMulta);
        }

        public int Eliminar(MultaBL pMulta)
        {
            return MultaDAL.Eliminar(pMulta);
        }

        public int ObtenerPorId(long pIdMulta)
        {
            return MultaDAL.ObtenerPorId(pIdMulta);
        }

        public int List<Multa> Buscar(Multa pMulta)
        {
            return MultaDAL.Buscar(pMulta);
        }
    }
}
