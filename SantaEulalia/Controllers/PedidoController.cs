using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa.AspNetCore;

namespace SantaEulalia.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Confirmar()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entDetalleVenta>>("carrito") ?? new List<entDetalleVenta>();

            if (!carrito.Any())
            {
                TempData["Mensaje"] = "No hay productos en el carrito.";
                return RedirectToAction("Tienda", "Producto");
            }

            ViewBag.Comprobantes = logComprobantePago.Instancia.ListarComprobantesPago()
                .Select(c => new SelectListItem
                {
                    Value = c.id_comprobante.ToString(),
                    Text = $"{c.tipo} - {c.serie}-{c.numero}"
                }).ToList();

            ViewBag.MetodosPago = logMetodoPago.Instancia.Listar()
                .Select(m => new SelectListItem
                {
                    Value = m.id_metodo_pago.ToString(),
                    Text = m.nombre
                }).ToList();

            return View(carrito);
        }

        [HttpPost]
        public IActionResult ConfirmarPedido(int idCliente, int idComprobante, int idMetodoPago, bool delivery = false)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entDetalleVenta>>("carrito") ?? new List<entDetalleVenta>();

            if (!carrito.Any())
            {
                TempData["Mensaje"] = "El carrito está vacío.";
                return RedirectToAction("Tienda", "Producto");
            }

            decimal total = carrito.Sum(d => d.PrecioUnitario * d.Cantidad);
            decimal totalDescuentoProductos = carrito.Sum(d => d.Subtotal - d.TotalConDescuento);
            decimal totalConDescuento = carrito.Sum(d => d.TotalConDescuento);

            var pedido = new entPedidoVenta
            {
                IdCliente = idCliente,
                IdUsuario = HttpContext.Session.GetInt32("id_usuario") ?? 1,
                IdComprobante = idComprobante,
                IdMetodoPago = idMetodoPago,
                Fecha = DateTime.Now,
                Total = total,
                TotalDescuentoProductos = totalDescuentoProductos,
                TotalDescuentoPromociones = 0,
                TotalConDescuento = totalConDescuento,
                Estado = "procesado",
                EsDelivery = delivery,
                Detalles = carrito
            };

            var exito = logVenta.Instancia.InsertarVenta(pedido);

            if (exito)
            {
                HttpContext.Session.Remove("carrito");
                return RedirectToAction("VerComprobante", new { idPedido = pedido.IdPedidoVenta });
            }

            TempData["Mensaje"] = "Error al registrar el pedido.";
            return RedirectToAction("Confirmar");
        }

        public IActionResult VerComprobante(int idPedido)
        {
            var pedido = logVenta.Instancia.BuscarVenta(idPedido);
            if (pedido == null)
                return NotFound();

            return View("Comprobante", pedido);
        }

        public IActionResult ExportarComprobante(int idPedido)
        {
            var pedido = logVenta.Instancia.BuscarVenta(idPedido);
            if (pedido == null)
                return NotFound();

            return new ViewAsPdf("Comprobante", pedido)
            {
                FileName = $"Comprobante_{idPedido}.pdf"
            };
        }
    }
}
