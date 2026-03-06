using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.BL
{
    public class CuotaBL
    {
        public int Guardar(Cuota pCuota)
        {
            return CuotaDAL.Guardar(pCuota);
        }
        public int Modificar(Cuota pCuota)
        {
            return CuotaDAL.Modificar(pCuota);
        }
        public int Eliminar(Cuota pCuota)
        {
            return CuotaDAL.Eliminar(pCuota);

        }
        public Cuota ObtenerPorId(long pIdCuota)
        {
            return CuotaDAL.ObtenerPorId(pIdCuota);
        }

        public List<Cuota> Buscar(Cuota pCuota)
        {
            return CuotaDAL.Buscar(pCuota);

        }
    }
}
