using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Rol
    {
        public int IdRol {  get; set; }
        public string NombreRol { get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
