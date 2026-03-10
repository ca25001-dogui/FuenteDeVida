using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Cuota
    {
        public string Descripcion;
        /// <summary>
        /// <b>PK:</b> Llave primaria de cuota
        /// </summary>
        public int IdCuota { get; set; }

        public int IdComunidad { get; set; }

        public decimal Monto { get; set; }
        public string TipoServicio { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }

        /// <summary>
        /// <b>FK:</b> Llave foranea de cuota que tiene relación con la entidad comunidad
        /// </summary>
        public short Comunidad { get; set; }

        /// <summary>
        ///  Propiedad virtual de <b>IdCargo (FK)</b> para representar la Asociacion
        /// </summary> 
        public virtual Comunidad Comunidad { get; set; } = new Comunidad();
        
    }
}
 
