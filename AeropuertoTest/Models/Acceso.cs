using System.ComponentModel.DataAnnotations;

namespace AeropuertoTest.Models
{
    public class Acceso
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display( Name ="Contraseña")]
        public string Contrasena { get; set; }
    }
}
