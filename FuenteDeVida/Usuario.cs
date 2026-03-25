using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteDeVida.EN
{
   public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido {  get; set; } = string.Empty;
        public string Correo {  get; set; } = string.Empty;
        public string Clave {  get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux { get; set; }

        //Llave foranea hacia Administrador 
        public int IdRol {  get; set; }
        public virtual Rol Rol { get; set; } = new Rol();
    }
}
