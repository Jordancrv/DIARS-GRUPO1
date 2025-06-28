using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class logComprobantePago
    {
        private static readonly logComprobantePago _instancia = new logComprobantePago();
        public static logComprobantePago Instancia => _instancia;

        public entComprobantePago ObtenerPorId(int id)
        {
            return datComprobantePago.Instancia.ObtenerPorId(id);
        }
        public int RegistrarPagoOrden(entPagoOrdenCompra pago)
        {
            return datOrdenCompra.Instancia.RegistrarPagoOrden(pago);
        }

    }
}
