using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
    }
}
