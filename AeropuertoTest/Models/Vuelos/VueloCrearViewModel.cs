using AeropuertoTest.Models.Aerolineas;
using AeropuertoTest.Models.Ciudades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeropuertoTest.Models.Vuelos
{
    public class VueloCrearViewModel
    {

        [Required]
        [Display(Name = "Ciudad origen")]
        public int CiudadOrigenId { get; set; }
        public Ciudad CiudadOrigen { get; set; }

        [Required]
        [Display(Name = "Ciudad destino")]
        public int CiudadDestinoId { get; set; }
        public List<Ciudad> CiudadDestino { get; set; }

        [Required]
        [Display(Name = "Fecha salida (AAA/MM/DD HH:mm:ss)")]
        public DateTime FechaSalida { get; set; }

        [Required]
        [Display(Name = "Fecha llegada (AAA/MM/DD HH:mm:ss)")]
        public DateTime FechaLlegada { get; set; }

        [Required]
        [Display(Name = "Numero vuelo")]
        public string NumeroVuelo { get; set; }

        [Required]
        [Display(Name = "Aerolinea")]
        public int AerolineaId { get; set; }
        public Aerolinea Aerolinea { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string EstadoVuelo { get; set; }
    }
}
