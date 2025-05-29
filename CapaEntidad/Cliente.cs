using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCliente
    {
        public int ClienteId { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public int DireccionID { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }
    }
}
