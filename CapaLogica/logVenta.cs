using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logVenta
    {
        #region singleton
        private static readonly logVenta UnicaInstancia = new logVenta();

        public static logVenta Instancia
        {
            get
            {
                return logVenta.UnicaInstancia;
            }
        }
        #endregion singleton

        #region Métodos

        public List<entPedidosVenta> ListarVentas()
        {
            return datVenta.Instancia.ListarVentas();
        }

        public bool InsertarVenta(entPedidosVenta venta, out int idVenta, out string mensaje)
        {
            return datVenta.Instancia.InsertarVenta(venta, out idVenta, out mensaje);
        }

        public bool EditarVenta(entPedidosVenta id_venta)
        {
            return datVenta.Instancia.EditarVenta(id_venta);
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

