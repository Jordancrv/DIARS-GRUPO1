public class PedidoViewModel
{
    public string NumeroPedido { get; set; } = null!;
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int EstadoId { get; set; }
    public int AlmacenId { get; set; }
    public int? CargoExtraId { get; set; }

    // Lista para los detalles, puede venir con un formulario dinámico
    public List<PedidoDetalleViewModel> Detalles { get; set; } = new List<PedidoDetalleViewModel>();
}

public class PedidoDetalleViewModel
{
    public int PresentacionId { get; set; }
    public int Cantidad { get; set; }
    public int PromocionId { get; set; }
}
