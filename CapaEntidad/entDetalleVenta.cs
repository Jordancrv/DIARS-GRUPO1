using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
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

        public entProductos Producto { get; set; }
    }
}
