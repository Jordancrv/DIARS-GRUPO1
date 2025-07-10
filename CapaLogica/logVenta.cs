using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logVenta
    {
        #region singleton
        private static readonly logVenta UnicaInstancia = new logVenta();

        public static logVenta Instancia
        {
            get { return logVenta.UnicaInstancia; }
        }
        #endregion singleton

        #region Métodos

        public List<entPedidoVenta> ListarVentas()
        {
            return datVenta.Instancia.ListarVentas();
        }
        public List<entPedidoVenta> ListarVentasProcesadas()
        {
            return datVenta.Instancia.ListarPedidosProcesados();
        }





        public bool InsertarVenta(entPedidoVenta venta)
        {
            return datVenta.Instancia.InsertarVenta(venta);
        }

        public bool EditarVenta(entPedidosVenta venta)
        {
            return datVenta.Instancia.EditarVenta(venta);
        }

        public entPedidosVenta BuscarVenta(int idVenta)
        {
            return datVenta.Instancia.BuscarVentaPorId(idVenta);
        }

        public bool EliminarVenta(int idVenta)
        {
            return datVenta.Instancia.AnularVenta(idVenta);
        }

        #endregion
    }
}
