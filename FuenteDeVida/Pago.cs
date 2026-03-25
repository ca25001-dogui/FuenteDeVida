using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Pago
    {
        [Key]
        public int IdPago {  get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        //Llave foranea 
        public int IdFactura { get; set; }
        public virtual Factura Factura { get; set; } = new Factura();
    }
}
