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
        public bool EsDelivery { get; set; }
        public string DireccionEntrega { get; set; }
        public int IdMetodoPago { get; set; }
        public int detalles { get; set; }
        public decimal Total { get; set; }
        public decimal TotalDescuentoProductos { get; set; }
        public decimal TotalDescuentoPromociones { get; set; }
        public decimal TotalConDescuento { get; set; }
        public string Estado { get; set; }

        // Relaciones (no se mapean directamente, solo para mostrar)
        public entComprobantePago Comprobante { get; set; }
        public entUsuario Usuario { get; set; }
        public entClientes Cliente { get; set; }

        public List<entDetalleVenta> Detalles { get; set; } = new List<entDetalleVenta>();
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

