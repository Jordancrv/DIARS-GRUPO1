using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Class1
    {
        public class entVenta
        {
            public int VentaId { get; set; }
            public string NumeroVenta { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Total { get; set; } 
            public int AlmacenId { get; set; } 
            public entClientes Cliente { get; set; }
            public entUsuario Vendedor { get; set; }
            public List<entVentaDetalle> Detalles { get; set; }
            public entPago Pago { get; set; }
            public entDespacho Despacho { get; set; }
            public bool Estado { get; set; }
        }

        public class entVentaDetalle
        {
            public entPresentacion Presentacion { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Descuento { get; set; }
            public entPromocion Promocion { get; set; }
            public decimal Subtotal { get; set; }
        }
        public class PagoEfectivo : entPago
        {
            public decimal Vuelto { get; set; }
        }

        public class PagoTarjeta : entPago
        {
            public string NumeroTarjeta { get; set; }
            public string TipoTarjeta { get; set; }
            public int Cuotas { get; set; }
        }
    }
}
