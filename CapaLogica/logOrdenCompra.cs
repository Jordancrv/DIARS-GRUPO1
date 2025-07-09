using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;


namespace CapaLogica
{
    public class logOrdenCompra
    {
        #region Singleton
        private static readonly logOrdenCompra _instancia = new logOrdenCompra();
        public static logOrdenCompra Instancia => _instancia;
        #endregion

        public List<OrdenCompra> ListarOrdenesCompra()
        {
            return datOrdenCompra.Instancia.ListarOrdenesCompra(); // método en capa datos
        }


        public bool InsertarOrdenCompraCompleta(OrdenCompra orden)
        {
            return datOrdenCompra.Instancia.InsertarOrdenCompraValidada(orden);
        }


        public bool AnularOrdenCompra(int idOrdenCompra)
        {
            return datOrdenCompra.Instancia.AnularOrdenCompra(idOrdenCompra);
        }
        public OrdenCompra ObtenerOrdenCompraPorId(int id)
        {
            return datOrdenCompra.Instancia.ObtenerOrdenCompraPorId(id);
        }
        public int RegistrarPagoOrden(entPagoOrdenCompra pago)
        {
            return datOrdenCompra.Instancia.RegistrarPagoOrden(pago);
        }
        public entPagoOrdenCompra ObtenerPagoPorComprobante(int idComprobante)
        {
            return datOrdenCompra.Instancia.ObtenerPagoPorComprobante(idComprobante);
        }
        public bool AnularPagoOrden(int idComprobante)
        {
            return datOrdenCompra.Instancia.AnularPagoOrden(idComprobante);
        }





    }
}
