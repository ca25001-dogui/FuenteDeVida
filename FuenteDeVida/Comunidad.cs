using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Comunidad
    {
        [Key]
        public int IdComunidad {  get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int CantidadUsuario { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
