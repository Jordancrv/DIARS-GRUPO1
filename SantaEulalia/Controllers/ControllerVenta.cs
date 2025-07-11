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

        //// GET: Mostrar detalles de una venta
        //[HttpGet]
        //public IActionResult Detalles(int id)
        //{
        //    try
        //    {
        //        var venta = logVenta.Instancia.BuscarVenta(id);
        //        if (venta == null)
        //            return NotFound();

        //        return View(venta);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return RedirectToAction("Listar");
        //    }
        //}

        // GET: Mostrar formulario para insertar venta

        [HttpGet]
        public IActionResult Insertar()
        {
            CargarListas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insertar(entPedidoVenta venta)
        {
            // Si el usuario no marcó ningún radio, el binder deja TipoComprobante vacío
            if (string.IsNullOrWhiteSpace(venta.TipoComprobante))
            {
                ModelState.AddModelError(nameof(venta.TipoComprobante),
                    "Debes seleccionar un tipo de comprobante.");
            }

            if (!ModelState.IsValid)
            {
                CargarListas();
                return View(venta);
            }

            try
            {
                // 1) Generar el comprobante (serie, número, id)
                var comp = logComprobantePago.Instancia.InsertarComprobantePago(venta.TipoComprobante);
                venta.IdComprobante = comp.id_comprobante;

                // 2) Insertar la venta (cabecera + detalles)
                bool ok = logVenta.Instancia.InsertarVenta(venta);
                if (ok)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo registrar la venta.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar la venta: " + ex.Message;
            }

            CargarListas();
            return View(venta);
        }

        private void CargarListas()
        {
            ViewBag.Clientes = logClientes.Instancia.ListarCliente();
            ViewBag.Productos = logProducto.Instancia.ListarProducto();
            ViewBag.Usuarios = logUsuario.Instancia.Listar();
            ViewBag.PromocionesPorProducto =
                logPromociones.Instancia.ListarPromocionesActivasPorProducto();
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

        public IActionResult Detalles(int id)
        {
            var pedido = logVenta.Instancia.ObtenerPedidoVentaPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        //[HttpPost]
        //public IActionResult GenerarComprobante(string tipo)
        //{
        //    try
        //    {
        //        var comprobante = logComprobantePago.Instancia.InsertarComprobantePago(tipo); // método modificado

        //        // Guardamos datos generados para mostrarlos en la vista
        //        TempData["mensaje"] = "Comprobante generado exitosamente.";
        //        TempData["tipo"] = comprobante.tipo;
        //        TempData["serie"] = comprobante.serie;
        //        TempData["numero"] = comprobante.numero;
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["error"] = "Error al generar comprobante: " + ex.Message;
        //    }

        //    return RedirectToAction("Insertar"); // Volvemos a la vista Insertar
        //}












        [HttpGet]
        public IActionResult GetPromocionActivaProducto(int idProducto) // Cambia JsonResult a IActionResult o sigue con JsonResult
        {
            try
            {
                // Llama a la capa de negocio para obtener la promoción
                entPromociones promocion = logPromociones.Instancia.BuscarPromocionActivaPorProducto(idProducto);

                if (promocion != null)
                {
                    // ¡ELIMINA JsonRequestBehavior.AllowGet! NO ES NECESARIO EN ASP.NET CORE.
                    return Json(new { success = true, promocion = promocion });
                }
                else
                {
                    // ¡ELIMINA JsonRequestBehavior.AllowGet!
                    return Json(new { success = false, message = "No se encontró promoción activa para este producto." });
                }
            }
            catch (System.Exception ex)
            {
                // En caso de error, devolver un mensaje de error
                // ¡ELIMINA JsonRequestBehavior.AllowGet!
                return Json(new { success = false, message = "Error al buscar promoción: " + ex.Message });
            }
        }












    }
}
