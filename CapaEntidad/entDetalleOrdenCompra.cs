using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class OrdenCompra
    {
        public int id_orden_compra { get; set; }
        public int? id_proveedor { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public decimal total { get; set; }
        public string tipo_orden { get; set; }

        public List<entDetalleOrdenCompra> detalles { get; set; } = new List<entDetalleOrdenCompra>();
    }

    public class entDetalleOrdenCompra
    {
        public int id_detalle { get; set; }
        public int id_orden_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal => cantidad * precio_unitario;
    }
}
