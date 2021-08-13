using System.ComponentModel.DataAnnotations;

namespace AeropuertoTest.Models.Ciudades
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
