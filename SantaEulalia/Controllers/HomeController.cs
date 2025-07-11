using System.Diagnostics;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using SantaEulalia.Models;

namespace SantaEulalia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult PanelUser()
        {
            int? idUsuario = HttpContext.Session.GetInt32("id_usuario");

            if (idUsuario == null)
                return RedirectToAction("Index", "Login");

            var cliente = logClientes.Instancia.ObtenerClientePorUsuarioId(idUsuario.Value);

            if (cliente == null)
                return RedirectToAction("Index", "Login");

            return View(cliente); // Esto requiere que tengas la vista PanelUser.cshtml
        }
    }
}
