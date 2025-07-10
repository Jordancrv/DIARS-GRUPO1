using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entComprobantePago
    {
        public int id_comprobante { get; set; }
        public string tipo { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public bool activo { get; set; }
    }
}
