using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPago
    {
        public int PagoId { get; set; }
        public entMetodoPago MetodoPago { get; set; }
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
