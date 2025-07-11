using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaLogica;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaEulalia.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var pedidos = logVenta.Instancia.ListarVentasProcesadas();

            var resumen = new ResumenVentasViewModel
            {
                TotalVentas = pedidos.Count,
                TotalIngresos = pedidos.Sum(p => p.TotalConDescuento),
                VentasPorFecha = pedidos
                    .GroupBy(p => p.Fecha.Date)
                    .Select(g => new VentaPorFechaViewModel
                    {
                        Fecha = g.Key,
                        Total = g.Sum(x => x.TotalConDescuento)
                    })
                    .OrderBy(v => v.Fecha)
                    .ToList(),

                VentasPorEstado = pedidos
                    .GroupBy(p => p.Estado)
                    .Select(g => new VentaPorEstadoViewModel
                    {
                        Estado = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList()
            };

            return View(resumen);
        }

        public IActionResult ExportarPDF()
        {
            var pedidos = logVenta.Instancia.ListarVentasProcesadas();
            var resumen = new ResumenVentasViewModel
            {
                TotalVentas = pedidos.Count,
                TotalIngresos = pedidos.Sum(p => p.TotalConDescuento),
                VentasPorFecha = pedidos
                    .GroupBy(p => p.Fecha.Date)
                    .Select(g => new VentaPorFechaViewModel
                    {
                        Fecha = g.Key,
                        Total = g.Sum(x => x.TotalConDescuento)
                    })
                    .OrderBy(v => v.Fecha)
                    .ToList(),

                VentasPorEstado = pedidos
                    .GroupBy(p => p.Estado)
                    .Select(g => new VentaPorEstadoViewModel
                    {
                        Estado = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList()
            };

            return new ViewAsPdf("ReportePDF", resumen)
            {
                FileName = "reporte_ventas.pdf"
            };
        }
    }

    public class ResumenVentasViewModel
    {
        public int TotalVentas { get; set; }
        public decimal TotalIngresos { get; set; }
        public List<VentaPorFechaViewModel> VentasPorFecha { get; set; }
        public List<VentaPorEstadoViewModel> VentasPorEstado { get; set; }
    }

    public class VentaPorFechaViewModel
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }

    public class VentaPorEstadoViewModel
    {
        public string Estado { get; set; }
        public int Cantidad { get; set; }
    }
}
