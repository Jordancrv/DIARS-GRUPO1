using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entMetodoPago
    {
        public int MetodoPagoId { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() => Descripcion;
    }
}
