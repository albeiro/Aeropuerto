using AeropuertoTest.Dominio.Aerolineas;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AeropuertoTest.Controllers
{
    public class AerolineaController : Controller
    {
        [HttpGet]
        public ActionResult Buscar()
        {
            var usuarioComandos = new AerolineaComandos();
            var ciudades = usuarioComandos.BuscarCiudad();
            return Content(JsonSerializer.Serialize(ciudades));
        }
    }
}