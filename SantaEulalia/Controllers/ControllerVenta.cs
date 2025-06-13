using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaLogica;

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
            public IActionResult InsertarVenta()
            {
                return View();
            }

            // POST: Insertar venta en la BD
            [HttpPost]
            public IActionResult InsertarVenta(entPedidosVenta venta)
            {
                try
                {
                    // Solo usamos el objeto venta, sin mensaje ni pedidoId
                    bool resultado = logVenta.Instancia.InsertarVenta(venta);

                    if (resultado)
                        return RedirectToAction("Listar");
                    else
                    {
                        ViewBag.Error = "No se pudo registrar la venta.";
                        return View(venta);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(venta);
                }
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
