using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Comunidad
    {
        public int IdComunidad {  get; set; }
        public decimal Monto { get; set; }
        public string TipoServicio { get; set; }
        public DateTime FechaLimite { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
