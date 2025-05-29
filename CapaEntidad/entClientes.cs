using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entClientes
    {
        public int id_cliente { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }

        // Colección de pedidos (opcional)
        public List<entPedidosVenta> Pedidos { get; set; }
    }
    public class entPedidosVenta
    {
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public decimal total { get; set; }

        // Propiedades de navegación
        public entClientes Cliente { get; set; }
        public entUsuario Usuario { get; set; }
        public List<entDetallesPedido> Detalles { get; set; }
    }
    public class entDetallesPedido
    {
        public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }

        // Propiedades de navegación
        public entPedidosVenta Pedido { get; set; }
        public entProductos Producto { get; set; }
    }
}
