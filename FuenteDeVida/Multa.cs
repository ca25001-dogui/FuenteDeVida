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
        
        public int IdMulta { get; set; }

        public decimal Monto { get; set; }    
        public DateTime FechaDeVencimiento { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        //LLave foranea 
        public int IdComunidad { get; set; }

        public virtual Comunidad Comunidad { get; set; } = new Comunidad();
    }
}
