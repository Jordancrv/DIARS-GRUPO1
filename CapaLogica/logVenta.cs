using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logVenta
    {
        #region Singleton
        private static readonly logVenta UnicaInstancia = new logVenta();
        public static logVenta Instancia => UnicaInstancia;
        #endregion

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


        public entPedidoVenta BuscarVenta(int idVenta)
        {
            return datVenta.Instancia.BuscarVentaPorId(idVenta);
        }

        public bool EliminarVenta(int idVenta)
        {
            return datVenta.Instancia.AnularVenta(idVenta);
        }

        public decimal ObtenerDescuentoPromocion(int idProducto)
        {
            return datVenta.Instancia.ObtenerDescuentoPromocion(idProducto);
        }

        #endregion
    }
}
