using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class ClienteCompraController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Esto devolverá la vista /Views/ClienteCompra/Index.cshtml
        }

        public IActionResult OrdenCompra() { return View(); }
        public IActionResult Cotizacion() { return View(); }
        public IActionResult Recepcion() { return View(); }
        public IActionResult Pago() { return View(); }
    }

}
