using System.ComponentModel.DataAnnotations;

namespace AeropuertoTest.Models.Aerolineas
{
    public class Aerolinea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
