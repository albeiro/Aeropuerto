using AeropuertoTest.Dominio.Ciudades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AeropuertoTest.Controllers
{
    public class CiudadController : Controller
    {
        [HttpGet]
        public ActionResult Buscar()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session))
            {
                return Redirect(Url.Content("~/Home/"));
            }

            var usuarioComandos = new CiudadComandos();
            var ciudades = usuarioComandos.BuscarCiudad();
            return Content(JsonSerializer.Serialize(ciudades));
        }
    }
}
