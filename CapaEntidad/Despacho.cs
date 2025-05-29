using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Despacho
    {
        public int DespachoId { get; set; }
        public int PedidoId { get; set; }
        public string ContactoNombres { get; set; }
        public string ContactoApellidos { get; set; }
        public string ContactoTelefono { get; set; }
        public string ContactoCorreo { get; set; }
        public int DireccionId { get; set; }
        public int ModalidadDespachoId { get; set; }
        public int ModalidadRecojoId { get; set; }
        public int EmpresaTransporteId { get; set; }
        public int ModalidadEntregaId { get; set; }
        public int AgenciaDestinoId { get; set; }
        public string RecojoNombres { get; set; }
        public string RecojoApellidos { get; set; }
        public string RecojoNumeroDocumento { get; set; }
    }
}
