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

        public int? IdUsuario { get; set; } // Puede ser nulo (venta online, por ejemplo)

        public DateTime Fecha { get; set; }

        public int IdComprobante { get; set; }

        public decimal Total { get; set; }

        public decimal TotalDescuentoProductos { get; set; }

        public decimal TotalDescuentoPromociones { get; set; }

        public decimal TotalConDescuento
        {
            get; set; // Total después de aplicar descuentos    
        }

        public string Estado { get; set; } // 'pendiente', 'procesado', 'anulado'

        public entComprobantePago Comprobante { get; set; } // Objeto asociado
        public entUsuario Usuario { get; set; } // Objeto asociado, puede ser nulo
        public entClientes Cliente { get; set; } // Objeto asociado  


        public List<entDetalleVenta> Detalles { get; set; } = new List<entDetalleVenta>();


    }




    public class entDetalleVenta
        {
            public int IdDetalle { get; set; }

            public int IdPedido { get; set; } // FK hacia PedidosVenta

            public int IdProducto { get; set; } // FK hacia Productos

            public int Cantidad { get; set; }

            public decimal PrecioUnitario { get; set; }

            // Subtotal se calcula automáticamente como Cantidad * PrecioUnitario
            public decimal Subtotal { get; set;  }

            public decimal Descuento { get; set; } // Porcentaje

            // TotalConDescuento también es calculado
            public decimal TotalConDescuento { get; set; }  
        }
    




    public class entComprobantePago
    {
        public int IdComprobante { get; set; }

        public string Tipo { get; set; } // 'factura', 'boleta', 'nota_credito'

        public string Serie { get; set; } // Puede considerarse como parte clave junto con Numero

        public string Numero { get; set; } // Combinado con Serie debe ser único

        public bool Activo { get; set; } // true = activo, false = inactivo
    }


    public class entVentaPromocion
    {
        public int IdPedido { get; set; }
        public int IdPromocion { get; set; }

        // Propiedades de navegación (opcional)
        public entPedidoVenta PedidoVenta { get; set; }
        public entPromocion Promocion { get; set; }
    }

    public class entProductoPromocion
    {
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }

        // Propiedades de navegación
        public entProductos Producto { get; set; }
        public entPromocion Promocion { get; set; }
    }









}




