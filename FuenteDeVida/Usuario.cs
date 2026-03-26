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

        //Llave foranea hacia Administrador 
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "La Clave debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        public string Clave { get; set; }
        public Rol Rol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

