using FuenteDeVida.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{

    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        // Usuario 
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // Comunidad 
        public int IdComunidad { get; set; }

        [ForeignKey("IdComunidad")]
        public Comunidad Comunidad { get; set; }
    }
}


