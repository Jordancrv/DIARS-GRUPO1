using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProveedor
    {
        public int id_proveedor { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public bool activo { get; set; }

        public List<string> telefonos { get; set; }
        public List<string> correos { get; set; }

        public entProveedor()
        {
            telefonos = new List<string>();
            correos = new List<string>();
        }
    }

}
