using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Factura
    {

        public int IdFactura { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        // Llave foránea Usuario
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = new Usuario();

        // Llave foránea Comunidad
        public int IdComunidad { get; set; }
        public virtual Comunidad Comunidad { get; set; } = new Comunidad();

    }

}

