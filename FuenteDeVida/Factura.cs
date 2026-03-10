using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Factura
    {
        public string Descripcion;
        /// <summary>
        /// <b>PK:</b> Llave primaria de Factura
        /// </summary>
        public int IdFactura { get; set; }

        public int IdUsuario { get; set; }
        public int IdComunidad { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }


        /// <summary>
        /// <b>FK:</b> Llave foranea de factura que tiene relación con la entidad usuario
        /// </summary>
        public short Usuario { get; set; }

        /// <summary>
        ///  Propiedad virtual de <b>IdCargo (FK)</b> para representar la Asociacion
        /// </summary> 
        public virtual Usuario Usuario { get; set; } = new Usuario();

        /// <summary>
        /// <b>FK:</b> Llave foranea de factura que tiene relación con la entidad comunidad
        /// </summary>
        public short Comunidad { get; set; }

        /// <summary>
        ///  Propiedad virtual de <b>IdCargo (FK)</b> para representar la Asociacion
        /// </summary> 
        public virtual Comunidad Comunidad { get; set; } = new Comunidad();

    }

}

