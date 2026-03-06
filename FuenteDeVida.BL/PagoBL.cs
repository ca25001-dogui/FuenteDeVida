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
        public int Guardar(PagoBL pPago)
        {
            return PagoDAL.Guardar(pPago);
        }
        public int Modificar(PagoBL pPago)
        {
            return PagoDAL.Modificar(pPago);
        }

        public int Eliminar(PagoBL pPago)
        {
            return PagoDAL.Eliminar(pPago);
        }

        public int ObtenerPorId(long pIdPago)
        {
            return PagoDAL.ObtenerPorId(pIdPago);
        }

        public int List<Pago> Buscar(Pago pPago)
        {
            return PagoDAL.Buscar(pPago);
        }
    }
}


