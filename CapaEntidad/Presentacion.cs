using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPresentacion
    {
        public int PresentacionId { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Unidades { get; set; } 
        public decimal Peso { get; set; } 
        public decimal Alto { get; set; } 
        public decimal Ancho { get; set; } 
        public decimal Largo { get; set; }

        public string DescripcionCompleta => $"{Producto?.Nombre} - {Nombre} ({Unidades} uni.)";

        public Dictionary<int, int> StockAlmacenes { get; set; } = new Dictionary<int, int>();
    }
}
