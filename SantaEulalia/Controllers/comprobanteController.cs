using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class comprobanteController : Controller
    {// GET: Listar comprobantes
        public IActionResult Listar()
        {
            var listaComprobantes = logComprobantesPago.Instancia.ListarComprobantes();
            ViewBag.Lista = listaComprobantes;
            return View(listaComprobantes);
        }

        // GET: Mostrar formulario para insertar comprobante
        [HttpGet]
        public IActionResult InsertarComprobante()
        {
            return View();
        }

        // POST: Insertar comprobante
        [HttpPost]
        public IActionResult InsertarComprobante(entComprobantePago comprobante)
        {
            try
            {
                bool insertado = logComprobantesPago.Instancia.InsertarComprobantes(comprobante);

                if (insertado)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo registrar el comprobante.";
                return View(comprobante);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View(comprobante);
            }
        }
    }
}
