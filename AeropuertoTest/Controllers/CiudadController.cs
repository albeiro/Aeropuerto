using AeropuertoTest.Dominio.Ciudades;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AeropuertoTest.Controllers
{
    public class CiudadController : Controller
    {
        [HttpGet]
        public ActionResult Buscar()
        {
            var usuarioComandos = new CiudadComandos();
            var ciudades = usuarioComandos.BuscarCiudad();
            return Content(JsonSerializer.Serialize(ciudades));
        }
    }
}
