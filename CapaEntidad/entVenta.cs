using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPedidoVenta
    {
        public int IdPedidoVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdComprobante { get; set; }

        public decimal Total { get; set; }
        public decimal TotalDescuentoProductos { get; set; }
        public decimal TotalDescuentoPromociones { get; set; }
        public decimal TotalConDescuento { get; set; }
        public string Estado { get; set; }
        public string TipoComprobante { get; set; }

        // Relaciones (no se mapean directamente, solo para mostrar)
        public entComprobantePago Comprobante { get; set; }
        public entUsuario Usuario { get; set; }
        public entClientes Cliente { get; set; }

        public List<entDetalleVenta> Detalles { get; set; } = new List<entDetalleVenta>();
    }

    public class entDetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalConDescuento { get; set; }

        public entProductos Producto { get; set; } // opcional si necesitas mostrar info del producto
    }

    public class entVentaPromocion
    {
        public int IdPedido { get; set; }
        public int IdPromocion { get; set; }

        public entPedidoVenta PedidoVenta { get; set; }
        public entPromocion Promocion { get; set; }
    }

    public class entProductoPromocion
    {
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }

        public entProductos Producto { get; set; }
        public entPromocion Promocion { get; set; }
    }

    public class entTipoPromocion
    {
        public int IdTipoPromocion { get; set; }
        public string NombreTipo { get; set; }
    }
}

