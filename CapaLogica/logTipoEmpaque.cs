using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logTipoEmpaque
    {
        private static readonly logTipoEmpaque _instancia = new logTipoEmpaque();
        public static logTipoEmpaque Instancia => _instancia;

        public List<entTipoEmpaque> ListarTipoEmpaque()
        {
            return datTipoEmpaque.Instancia.Listar();
        }
    }

}
