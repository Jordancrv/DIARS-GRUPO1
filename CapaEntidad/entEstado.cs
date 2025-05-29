using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entEstado
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }

        public const int ACTIVO = 1;
        public const int INACTIVO = 2;
        public const int PENDIENTE = 3;
        public const int COMPLETADO = 4;
        public const int ANULADO = 5;

        public override string ToString() => Nombre;
    }
}
