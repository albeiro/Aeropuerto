using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeropuertoTest.Models.Vuelos
{
    public class VueloBuscarViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ciudad origen")]
        public string CiudadOrigen { get; set; }

        [Required]
        [Display(Name = "Ciudad destino")]
        public string CiudadDestino { get; set; }

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
        public string Aerolinea { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string EstadoVuelo { get; set; }
    }
}
