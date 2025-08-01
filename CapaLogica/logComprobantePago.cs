﻿using CapaEntidad;
using CapaDatos;
using System.Collections.Generic;

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

        public List<entComprobantePago> Listar()
        {
            return datComprobantePago.Instancia.ListarComprobantesPago();
        }

        public List<entComprobantePago> ListarComprobantesPago()
        {
            return datComprobantePago.Instancia.ListarComprobantesPago();
        }
        public decimal ObtenerDescuentoPromocion(int idProducto)
        {
            return datVenta.Instancia.ObtenerDescuentoPromocion(idProducto);
        }
    }
}
