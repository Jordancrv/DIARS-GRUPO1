using CapaDatos;
using CapaEntidad;
using System;
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



         public entPedidoVenta ObtenerPedidoVentaPorId(int id)
        {
            return datVenta.Instancia.ObtenerPedidoVentaPorId(id);
        }

       

        public bool EditarVenta(entPedidosVenta venta)
        {
            return datVenta.Instancia.EditarVenta(venta);
        }

        public bool InsertarVenta(entPedidoVenta venta)
        {
            try
            {
                // 1. Validar si hay suficiente stock
                foreach (var detalle in venta.Detalles)
                {
                    var producto = logProducto.Instancia.BuscarProducto(detalle.IdProducto);
                    if (producto.stock < detalle.Cantidad)
                    {
                        throw new Exception($"Stock insuficiente para el producto {producto.nombre}. Stock actual: {producto.stock}, requerido: {detalle.Cantidad}");
                    }
                }

                // 2. Registrar venta (suponiendo que ya lo haces en la BD con transacción)
                bool registrado = datVenta.Instancia.InsertarVenta(venta); // Inserta cabecera y detalle

                if (!registrado) return false;

                // 3. Descontar stock y verificar stock mínimo
                foreach (var detalle in venta.Detalles)
                {
                    var producto = logProducto.Instancia.BuscarProducto(detalle.IdProducto);
                    producto.stock -= detalle.Cantidad;

                    logProducto.Instancia.ActualizarStock(detalle.IdProducto, producto.stock);

                    if (producto.stock <= producto.stock_minimo)
                    {
                        // Aquí podrías enviar un correo o loguear la alerta
                        Console.WriteLine($"⚠️ Alerta: El producto '{producto.nombre}' ha llegado al stock mínimo.");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la venta: " + ex.Message);
            }
        }



        //para anular venta 
        public entPedidoVenta BuscarVenta(int idVenta)
        {
            return datVenta.Instancia.BuscarVentaPorId(idVenta);
        }

        public bool EliminarVenta(int idVenta)
        {
            return datVenta.Instancia.AnularPedidoVenta(idVenta);
        }

        #endregion
    }
}
