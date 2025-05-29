using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SantaEulalia.ViewModels
{
    public class VentaViewModel
    {
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int AlmacenId { get; set; }

        public List<DetalleVentaViewModel> Detalles { get; set; } = new();
    }

    public class DetalleVentaViewModel
    {
        public int PresentacionId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public int? PromocionId { get; set; }
    }



}
