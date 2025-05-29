using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Almacen
    {
        public int id_almacen { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}

