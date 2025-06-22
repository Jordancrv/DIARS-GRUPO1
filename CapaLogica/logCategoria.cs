using CapaEntidad;
using CapaDatos;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logCategoria
    {
        private static readonly logCategoria _instancia = new logCategoria();
        public static logCategoria Instancia => _instancia;

        public List<entCategoria> ListarCategorias()
        {
            return datCategoria.Instancia.Listar();
        }
    }
}
