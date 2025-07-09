using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPedidoVenta
    {

        public int IdPedidoVenta { get; set; } // Puede ser int? si es generado por DB y no siempre se envía
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; } // Correcto, puede ser nulo
        public DateTime Fecha { get; set; } // ✅ Importante: Esta se debe establecer en el backend (DateTime.Now) o añadir un input oculto si la envías desde el frontend. Si no la envías y no es nullable, fallará el binding. Por ahora, asumo que la estableces en el backend.
        public int IdComprobante { get; set; }

        public decimal Total { get; set; } // Suma de (Cantidad * PrecioUnitario) de detalles
        public decimal TotalDescuentoProductos { get; set; } // Suma de los montos de descuento de cada detalle
        public decimal TotalDescuentoPromociones { get; set; } // ✅ Si no hay input para esto, debe ser decimal? o inicializarse a 0 en el backend. Lo añadiremos como input oculto en la vista.

        public decimal TotalConDescuento { get; set; } // Total - TotalDescuentoProductos - TotalDescuentoPromociones

        public string Estado { get; set; }

        // Propiedades de navegación (no necesitan ser nullable si solo se usan para display o si el binding no las intenta llenar)
        public entComprobantePago Comprobante { get; set; }
        public entUsuario Usuario { get; set; }
        public entClientes Cliente { get; set; }

        public List<entDetalleVenta> Detalles { get; set; } = new List<entDetalleVenta>();

        public entPedidoVenta()
    {
         Detalles = new List<entDetalleVenta>();
     }


    }




    public class entDetalleVenta
    {
        public int IdDetalle { get; set; } // ✅ Hazlo nullable: Generalmente generado por DB
        public int IdPedido { get; set; } // ✅ Hazlo nullable: FK se asigna en el controlador/servicio, no en el form

        public int IdProducto { get; set; } // Este es requerido (viene del select)
        public int Cantidad { get; set; } // Este es requerido (viene del input number)
        public decimal PrecioUnitario { get; set; } // Este es requerido (viene del input number)

        public decimal Subtotal { get; set; } // ✅ Hazlo nullable: Es calculado (Cantidad * PrecioUnitario), no se envía como input para cada detalle.
        public decimal Descuento { get; set; } // Este es el porcentaje (viene del input number)

        public decimal TotalConDescuento { get; set; } // ✅ Hazlo nullable: Este es el MONTO del descuento para este producto. Se calcula en JS y lo enviaremos como input oculto.
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


    public class entTipoPromocion
    {
        public int IdTipoPromocion { get; set; }
        public string NombreTipo { get; set; }
    }





}




