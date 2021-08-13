using AeropuertoTest.Models.Ciudades;
using System;
using System.ComponentModel.DataAnnotations;

namespace AeropuertoTest.Models.Vuelos
{
    public class Vuelo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int CiudadOrigenId { get; set; }

        [Required]
        [Display(Name = "Ciudad origen")]
        public Ciudad CiudadOrigen { get; set; }

        [Required]
        [Display(Name = "Ciudad destino")]
        public int CiudadDestinoId { get; set; }
        public Ciudad CiudadDestino { get; set; }

        [Required]
        [Display(Name = "Fecha salida")]
        public DateTime FechaSalida { get; set; }

        [Required]
        [Display(Name = "Fecha llegada")]
        public DateTime FechaLlegada { get; set; }

        [Required]
        [Display(Name = "Numero vuelo")]
        public string NumeroVuelo { get; set; }

        [Required]
        [Display(Name = "Aerolinea")]
        public int AerolineaId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string EstadoVuelo { get; set; }

    }
}
