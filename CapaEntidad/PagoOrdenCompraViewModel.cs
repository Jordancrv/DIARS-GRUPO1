using System;

namespace CapaEntidad
{
    public class entPagoOrdenCompra
    {
        public int IdPago { get; set; }                    // <-- Agregado
        public int IdOrdenCompra { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Monto { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Observaciones { get; set; }
        public int IdComprobante { get; set; }
        public DateTime FechaPago { get; set; }            // <-- Agregado
        public string Estado { get; set; }                 // <-- Agregado
    }
}
