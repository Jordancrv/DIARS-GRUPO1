using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logMetodoPago
    {
        private static readonly logMetodoPago _instancia = new logMetodoPago();
        public static logMetodoPago Instancia => _instancia;

        public List<MetodoPago> Listar()
        {
            return datMetodoPago.Instancia.Listar();
        }
    }
}
