using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Multa
    {
        
        public int Id { get; set; }

        public int IdComunidad { get; set; }

        public decimal Monto { get; set; }    
        public DateTime FechaDeVencimiento { get; set; }

        [NotMapped]
        public int TopAux { get; set; }
    }
}
