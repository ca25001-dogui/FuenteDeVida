using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Pago
    {
        public int Id {  get; set; }

        public int IdFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }

        [NotMapped]
        public int TopAux { get; set; }
    }
}
