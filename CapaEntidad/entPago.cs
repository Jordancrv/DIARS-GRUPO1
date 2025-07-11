using System;

namespace CapaEntidad
{
    public class entPago
    {
        public int PagoId { get; set; }
        public MetodoPago MetodoPago { get; set; } // ✅ Aquí corregido el tipo
        public entEstado Estado { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
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
        public string CodigoAutorizacion { get; set; }
    }
}
