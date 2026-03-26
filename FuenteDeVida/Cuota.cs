using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
    public class Cuota
    {
        [Key]
            public int IdCuota { get; set; }

            public decimal Monto { get; set; }
            public string TipoServicio { get; set; } = string.Empty;
            public DateTime FechaLimite { get; set; }

            [NotMapped]
            public int Top_Aux { get; set; }

            // Llave foránea
            public int IdComunidad { get; set; }
            public virtual Comunidad Comunidad { get; set; } = new Comunidad();
        
    }
}

 
