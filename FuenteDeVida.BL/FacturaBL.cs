using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.BL
{
    public class FacturaBL
    {
        public int Guardar(Factura pFactura)
        {
            return FacturaDAL.Guardar(pFactura);
        }
        public int Modificar(Factura pFactura)
        {
            return FacturaDAL.Modificar(pFactura);
        }

        public int Eliminar(Factura pFactura)
        {
            return FacturaDAL.Eliminar(pFactura);
        }

        public Factura ObtenerPorId(long pIdFactura)
        {
            return FacturaDAL.ObtenerPorId(pIdFactura);
        }
        public List<Factura> Buscar(Factura pFactura)
        {
            return FacturaDAL.Buscar(pFactura);
        }
    }
}
       