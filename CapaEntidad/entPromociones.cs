using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class entPromociones
    {

        public int IdPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string TipoPromocion { get; set; } // nombre del tipo
        public int IdTipoPromocion { get; set; }  // para insertar
        public bool Estado { get; set; }


    }
}
