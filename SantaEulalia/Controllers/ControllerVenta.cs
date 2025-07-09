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
                ViewBag.Lista = listaVentas;
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

        // GET: Mostrar formulario para insertar venta

        [HttpGet]
        public IActionResult Insertar()
        {
            // Si necesitas cargar listas (como clientes o productos), hazlo aquí
            ViewBag.Clientes = logClientes.Instancia.ListarCliente();
            ViewBag.Productos = logProducto.Instancia.ListarProducto();
            ViewBag.Comprobantes = logComprobantePago.Instancia.ListarComprobantesPago();
            ViewBag.Usuarios = logUsuario.Instancia.Listar();

            return View();
        }

        // POST: Insertar una nueva venta
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

            // Recarga listas en caso de error para que el formulario siga funcionando
            ViewBag.Clientes = logClientes.Instancia.ListarCliente();
            ViewBag.Productos = logProducto.Instancia.ListarProducto();
            ViewBag.Comprobantes = logComprobantePago.Instancia.ListarComprobantesPago();
            ViewBag.Usuarios = logUsuario.Instancia.Listar();

            return View(venta);
        }

        // GET: Mostrar formulario para editar venta
        [HttpGet]
            public IActionResult EditarVenta(int id)
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

            // POST: Actualizar venta en la BD
            [HttpPost]
            public IActionResult EditarVenta(entPedidosVenta venta)
            {
                try
                {
                    bool resultado = logVenta.Instancia.EditarVenta(venta);

                    if (resultado)
                        return RedirectToAction("Listar");
                    else
                        return View(venta);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(venta);
                }
            }

            // GET: Mostrar confirmación para eliminar venta
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

            // POST: Confirmar eliminación de venta
            [HttpPost, ActionName("EliminarVenta")]
            public IActionResult EliminarVentaConfirmado(int id)
            {
                try
                {
                    bool eliminado = logVenta.Instancia.EliminarVenta(id);
                    if (eliminado)
                        return RedirectToAction("Listar");
                    else
                    {
                        ViewBag.Error = "No se pudo eliminar la venta.";
                        var venta = logVenta.Instancia.BuscarVenta(id);
                        return View("EliminarVenta", venta);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    var venta = logVenta.Instancia.BuscarVenta(id);
                    return View("EliminarVenta", venta);
                }
            }
        






    }
}
