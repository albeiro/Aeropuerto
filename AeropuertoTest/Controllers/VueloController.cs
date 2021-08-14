using AeropuertoTest.Dominio.Vuelos;
using AeropuertoTest.Models.Vuelos;
using Microsoft.AspNetCore.Mvc;

namespace AeropuertoTest.Controllers
{
    public class VueloController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var vueloComandos = new VueloComandos();
            var vuelos = vueloComandos.BuscarVuelos();
            return View(vuelos);
        }

        [HttpPost]
        public ActionResult EliminarVuelo(int id)
        {
            var vueloComandos = new VueloComandos();
            var vuelos = vueloComandos.EliminarVuelo(id);
            return Content(vuelos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(VueloCrearViewModel vuelo)
        {
            if (!ModelState.IsValid )
            {
                return View(vuelo);
            }

            var vueloComandos = new VueloComandos();
            var crear = vueloComandos.CrearVuelo(vuelo);
            if (string.IsNullOrEmpty(crear)) 
            {
                return Redirect(Url.Content("~/Vuelo/"));
            }
            return View(vuelo);
        }

        [HttpGet]
        public ActionResult ActualizarVuelo(int id)
        {
            var vueloComandos = new VueloComandos();
            var vuelo = vueloComandos.BuscarVuelosPorId(id);
            if (vuelo == null)
            {
                return Content("No existe vuelo");
            }
            return View(vuelo);
        }

        [HttpPost]
        public ActionResult ActualizarVuelo(VueloActualizarViewModel vuelo)
        {

            var vueloComandos = new VueloComandos();
            var vueloActualizar = vueloComandos.Actualizarvuelo(vuelo);
            if (string.IsNullOrEmpty(vueloActualizar))
            {
                return Redirect(Url.Content("~/Vuelo/"));
            }
            return View(vuelo.Id);
        }
    }
}
