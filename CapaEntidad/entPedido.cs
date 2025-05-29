// En el proyecto o carpeta Entidades

using System.Collections.Generic;
using System;

public class Pedido
{
    public int PedidoId { get; set; }
    public string NumeroPedido { get; set; } 
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public int EstadoId { get; set; }
    public int AlmacenId { get; set; }
    public int? CargoExtraId { get; set; }

    public List<PedidoDetalle> Detalles { get; set; }
}

public class PedidoDetalle
{
    public int PedidoId { get; set; }
    public int PresentacionId { get; set; }
    public int Cantidad { get; set; }
    public int PromocionId { get; set; }
}
