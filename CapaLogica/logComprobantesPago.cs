using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaLogica
{
    public class logComprobantesPago
    {


        private static readonly logComprobantesPago _instancia = new logComprobantesPago();
        public static logComprobantesPago Instancia => _instancia;

        public List<entComprobantePago> ListarComprobantes()
        {
            return datVenta.Instancia.ListarComprobantes();
        }

        public bool InsertarComprobantes(entComprobantePago comprobante) 
        {
            return datVenta.Instancia.InsertarComprobante(comprobante);
        }







    }
}
