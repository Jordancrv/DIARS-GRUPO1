using CapaDatos;
using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SantaEulalia.Controllers
{
    public class ControllerVenta : Controller
    {
        // GET: Listar ventas
        public IActionResult Listar()
        {
            var listaVentas = logVenta.Instancia.ListarVentas();
            return View(listaVentas);
        }

        // GET: Mostrar detalles de una venta
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            try
            {
                var venta = logVenta.Instancia.BuscarVenta(id);
                if (venta == null)
                    return NotFound();

                return View(venta);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // GET: Mostrar formulario para insertar venta manualmente
        [HttpGet]
        public IActionResult Insertar()
        {
            ViewBag.Clientes = logClientes.Instancia.ListarCliente();
            ViewBag.Productos = logProducto.Instancia.ListarProducto();
            ViewBag.Comprobantes = logComprobantePago.Instancia.ListarComprobantesPago();
            ViewBag.Usuarios = logUsuario.Instancia.Listar();
            ViewBag.PromocionesPorProducto = logPromociones.Instancia.ListarPromocionesActivasPorProducto();

            return View();
        }

        // POST: Insertar nueva venta
        [HttpPost]
        public IActionResult Insertar(entPedidoVenta venta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool resultado = logVenta.Instancia.InsertarVenta(venta);
                    if (resultado)
                        return RedirectToAction("Listar");

                    ViewBag.Error = "No se pudo registrar la venta.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar la venta: " + ex.Message;
            }

            // Recargar combos en caso de error
            ViewBag.Clientes = logClientes.Instancia.ListarCliente();
            ViewBag.Productos = logProducto.Instancia.ListarProducto();
            ViewBag.Comprobantes = logComprobantePago.Instancia.ListarComprobantesPago();
            ViewBag.Usuarios = logUsuario.Instancia.Listar();
            ViewBag.PromocionesPorProducto = logPromociones.Instancia.ListarPromocionesActivasPorProducto();

            return View(venta);
        }

        // GET: Confirmar eliminación
        [HttpGet]
        public IActionResult EliminarVenta(int id)
        {
            try
            {
                var venta = logVenta.Instancia.BuscarVenta(id);
                if (venta == null)
                    return NotFound();

                return View(venta);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Confirmar eliminación definitiva
        [HttpPost, ActionName("EliminarVenta")]
        public IActionResult EliminarVentaConfirmado(int id)
        {
            try
            {
                bool eliminado = logVenta.Instancia.EliminarVenta(id);
                if (eliminado)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo eliminar la venta.";
                var venta = logVenta.Instancia.BuscarVenta(id);
                return View("EliminarVenta", venta);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                var venta = logVenta.Instancia.BuscarVenta(id);
                return View("EliminarVenta", venta);
            }
        }

        // GET: Obtener promoción activa de un producto
        [HttpGet]
        public IActionResult GetPromocionActivaProducto(int idProducto)
        {
            try
            {
                var promocion = logPromociones.Instancia.BuscarPromocionActivaPorProducto(idProducto);

                if (promocion != null)
                {
                    return Json(new { success = true, promocion = promocion });
                }

                return Json(new { success = false, message = "No se encontró promoción activa para este producto." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al buscar promoción: " + ex.Message });
            }
        }
    }
}
