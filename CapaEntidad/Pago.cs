using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        public int PagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public Estado Estado { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }

    public class PagoEfectivo : Pago
    {
        public decimal Vuelto { get; set; }
    }

    public class PagoTarjeta : Pago
    {
        public string NumeroTarjeta { get; set; }
        public string TipoTarjeta { get; set; }
        public int Cuotas { get; set; }
        public string CodigoAutorizacion { get; set; }
    }
}
