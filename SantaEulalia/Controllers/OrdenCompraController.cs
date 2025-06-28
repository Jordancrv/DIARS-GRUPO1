using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapaEntidad;
using CapaLogica;
using Rotativa.AspNetCore;
using System.Collections.Generic;

public class OrdenCompraController : Controller
{
    public IActionResult Listar()
    {
        var lista = logOrdenCompra.Instancia.ListarOrdenesCompra();
        return View(lista);
    }

    public IActionResult Crear()
    {
        ViewBag.Proveedores = new SelectList(logProveedores.Instancia.ListarProveedores(), "id_proveedor", "razon_social");
        ViewBag.Productos = logProducto.Instancia.ListarProducto();
        return View(new OrdenCompra());
    }

    public IActionResult Pagar(int id)
    {
        var orden = logOrdenCompra.Instancia.ObtenerOrdenCompraPorId(id);
        if (orden == null || orden.estado != "pendiente")
        {
            TempData["Error"] = "La orden no existe o ya fue procesada.";
            return RedirectToAction("Listar");
        }
        var metodos = logMetodoPago.Instancia.Listar();
        ViewBag.MetodosPago = new SelectList(logMetodoPago.Instancia.Listar(), "id_metodo_pago", "nombre");
        return View(new entPagoOrdenCompra { IdOrdenCompra = id, Monto = orden.total });
    }
    public IActionResult DescargarPDF(int id)
    {
        var comprobante = logComprobantePago.Instancia.ObtenerPorId(id);
        var pago = logOrdenCompra.Instancia.ObtenerPagoPorComprobante(id); // Debes haber creado este método
        var orden = logOrdenCompra.Instancia.ObtenerOrdenCompraPorId(pago.IdOrdenCompra);

        var vm = new OrdenCompraComprobanteViewModel
        {
            Orden = orden,
            Comprobante = comprobante
        };

        return new ViewAsPdf("OrdenCompraPDF", vm)
        {
            FileName = $"OrdenCompra_{orden.id_orden_compra}.pdf",
            PageSize = Rotativa.AspNetCore.Options.Size.A4,
            PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            CustomSwitches = "--disable-smart-shrinking --viewport-size 1280x1024"
        };
    }
    public IActionResult AnularPago(int id)
    {
        try
        {
            bool resultado = logOrdenCompra.Instancia.AnularPagoOrden(id);
            if (!resultado)
            {
                TempData["Error"] = "No se pudo anular el pago.";
            }
            else
            {
                TempData["Mensaje"] = "Pago anulado correctamente.";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error al anular el pago: " + ex.Message;
        }

        return RedirectToAction("Listar"); // O redirige a MostrarComprobante si prefieres
    }




    public IActionResult MostrarComprobante(int id)
    {
        var comprobante = logComprobantePago.Instancia.ObtenerPorId(id);
        var pago = logOrdenCompra.Instancia.ObtenerPagoPorComprobante(id);
        var orden = logOrdenCompra.Instancia.ObtenerOrdenCompraPorId(pago.IdOrdenCompra);

        if (comprobante == null || pago == null || orden == null)
            return NotFound("No se encontró el comprobante o su información asociada.");

        var viewModel = new ComprobantePagoViewModel
        {
            Comprobante = comprobante,
            Pago = pago,
            Orden = orden
        };

        return View(viewModel);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Pagar(entPagoOrdenCompra pago)
    {
        if (ModelState.IsValid)
        {
            try
            {
                int idComprobante = logOrdenCompra.Instancia.RegistrarPagoOrden(pago);

                if (idComprobante > 0)
                {
                    return RedirectToAction("MostrarComprobante", new { id = idComprobante });
                }

                ModelState.AddModelError("", "No se pudo registrar el pago.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }

        ViewBag.MetodosPago = new SelectList(logMetodoPago.Instancia.Listar(), "id_metodo_pago", "nombre");
        return View(pago);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(OrdenCompra orden)
    {
        if (ModelState.IsValid)
        {
            try
            {
                logOrdenCompra.Instancia.InsertarOrdenCompraCompleta(orden);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }

        ViewBag.Proveedores = new SelectList(logProveedores.Instancia.ListarProveedores(), "id_proveedor", "razon_social");
        ViewBag.Productos = logProducto.Instancia.ListarProducto();
        return View(orden);
    }

    public IActionResult Details(int id)
    {
        var orden = logOrdenCompra.Instancia.ObtenerOrdenCompraPorId(id);
        if (orden == null)
        {
            return NotFound();
        }

        return View(orden);
    }

    public IActionResult Anular(int id)
    {
        bool result = logOrdenCompra.Instancia.AnularOrdenCompra(id);
        if (!result)
        {
            TempData["Error"] = "No se pudo anular la orden o ya está procesada.";
        }
        return RedirectToAction("Listar");
    }
}
