using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCarrito
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string imagen_url { get; set; }
        public decimal precioventa { get; set; }
        public int cantidad { get; set; }
    }

    public class CarritoItem
    {
        public entProductos Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
