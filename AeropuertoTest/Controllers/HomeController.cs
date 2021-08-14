using AeropuertoTest.Dominio.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AeropuertoTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IniciarSesion(string usuario, string contrasena)
        {
            var usuarioComandos = new UsuarioComandos();
            var result = usuarioComandos.BuscarUsuario(usuario, contrasena);

            if (result == usuario)
            {
                HttpContext.Session.SetString("Usuario", usuario);
            }
            return Content(result);
        }

    }
}
