using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPresentacion
    {
        private static readonly logPresentacion _instancia = new logPresentacion();
        public static logPresentacion Instancia => _instancia;

        public List<entPresentacion> ListarPresentaciones()
        {
            return datPresentacion.Instancia.Listar();
        }
    }

}
