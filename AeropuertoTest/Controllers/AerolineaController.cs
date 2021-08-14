using AeropuertoTest.Dominio.Aerolineas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AeropuertoTest.Controllers
{
    public class AerolineaController : Controller
    {
        [HttpGet]
        public ActionResult Buscar()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session))
            {
                return Redirect(Url.Content("~/Home/"));
            }

            var usuarioComandos = new AerolineaComandos();
            var ciudades = usuarioComandos.BuscarCiudad();
            return Content(JsonSerializer.Serialize(ciudades));
        }
    }
}