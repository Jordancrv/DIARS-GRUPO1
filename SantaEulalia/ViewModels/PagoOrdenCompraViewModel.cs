namespace SantaEulalia.ViewModels
{
    public class PagoOrdenCompraViewModel
    {
        public int IdOrdenCompra { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Monto { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Observaciones { get; set; }
    }
}
