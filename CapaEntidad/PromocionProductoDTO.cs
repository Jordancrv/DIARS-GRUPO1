using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PromocionProductoDTO
    {

        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public decimal Descuento { get; set; }
        public string TipoPromocion { get; set; }

    }
}
