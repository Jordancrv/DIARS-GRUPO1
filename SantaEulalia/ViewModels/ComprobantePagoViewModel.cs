namespace CapaEntidad
{
    public class ComprobantePagoViewModel
    {
        public entComprobantePago Comprobante { get; set; }
        public entPagoOrdenCompra Pago { get; set; }
        public OrdenCompra Orden { get; set; } // opcional si deseas mostrar detalles de la orden
    }
}
