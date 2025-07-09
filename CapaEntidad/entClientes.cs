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
        public int id_tipo_cliente { get; set; } // 1: Persona Natural, 2: Persona Jurídica
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; } // Solo para Persona Natural

        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string idUsuario { get; set; } // Usuario que creó el cliente    

        public bool activo { get; set; }

        // NUEVO:
        public List<string> telefonos { get; set; }
        public List<string> correos { get; set; }

        public entClientes()
        {
            telefonos = new List<string>();
            correos = new List<string>();
        }
    }
    public class entPedidosVenta
    {
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }


        // Propiedades de navegación
        public entClientes Cliente { get; set; }
        public entUsuario Usuario { get; set; }
        public List<entDetallesVenta> Detalles { get; set; }
    }
    public class entDetallesVenta
    {
        public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal => cantidad * precio_unitario;

        // Propiedades de navegación
        public entPedidosVenta Pedido { get; set; }
        public entProductos Producto { get; set; }
    }
}
