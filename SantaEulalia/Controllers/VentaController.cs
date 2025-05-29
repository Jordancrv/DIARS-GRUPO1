using Microsoft.AspNetCore.Mvc;
using CapaLogica;
using SantaEulalia.ViewModels;
using CapaEntidad;
using SantaEulalia.ViewModels;
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

        entVenta venta = new entVenta
        {
            Cliente = new entCliente { ClienteId = model.ClienteId },
            Vendedor = new entUsuario { UsuarioId = model.UsuarioId },
            AlmacenId = model.AlmacenId,
            Detalles = model.Detalles.Select(d => new entVentaDetalle
            {
                Presentacion = new entPresentacion { PresentacionId = d.PresentacionId },
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Descuento = d.Descuento,
                Promocion = d.PromocionId.HasValue ? new Promocion { PromocionId = d.PromocionId.Value } : null
            }).ToList()
        };

        int ventaId;
        string mensaje;

        bool exito = new VentaBL().RegistrarVenta(venta, out ventaId, out mensaje);

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
