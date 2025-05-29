using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; } = true;

        public List<Producto> Productos { get; set; }

        public override string ToString() => Nombre;
    }
}
