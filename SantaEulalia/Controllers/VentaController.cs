using Microsoft.AspNetCore.Mvc;
using CapaLogica;
using CapaEntidad;
using SantaEulalia.ViewModels;
using System.Linq;
using System.Collections.Generic;
using static CapaEntidad.Class1;

public class VentaController : Controller
{
    [HttpGet]
    public IActionResult AgregarVenta()
    {
        var model = new VentaViewModel
        {
            Detalles = new List<DetalleVentaViewModel>
            {
                new DetalleVentaViewModel()
            }
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult AgregarVenta(VentaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Datos inválidos";
            return View(model);
        }

        // Mapear ViewModel a entidad entVenta
        entVenta venta = new entVenta
        {
            Cliente = new entClientes { id_cliente = model.ClienteId },
            Vendedor = new entUsuario { id_usuario = model.UsuarioId },
            AlmacenId = model.AlmacenId,
            Estado = true,
            Detalles = model.Detalles.Select(d => new entVentaDetalle
            {
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario, 
                Descuento = d.Descuento,
                Promocion = d.PromocionId.HasValue ? new entPromocion { PromocionId = d.PromocionId.Value } : null
            }).ToList()
        };

        int ventaId;
        string mensaje;

        bool exito = VentaBL.Instancia.RegistrarVenta(venta, out ventaId, out mensaje);

        if (exito)
        {
            TempData["Mensaje"] = $"Venta registrada con ID: {ventaId}";
            return RedirectToAction("AgregarVenta");
        }
        else
        {
            TempData["Error"] = mensaje;
            return View(model);
        }
    }
}
