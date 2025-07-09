using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPromociones
    {

        public int IdPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int idTipoPromocion { get; set; }  // lo que necesitamos es mostarr nombres pero cuando se elijan alguno // de los tipos de promociones, se guarde el id_tipo_promocion
        public string TipoPromocion { get; set; } // Solo para mostrar (join en el SP)
        public bool Estado { get; set; }


    }




}
