using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Multa
    {
        [Key]
        
        public int IdMulta { get; set; }

        public decimal Monto { get; set; }    
        public DateTime FechaVencimiento { get; set; }

        //Auxiliar para busqueda
        [NotMapped]
        public int Top_Aux { get; set; }

        //LLave foranea 
        public int IdComunidad { get; set; }
    }
}
