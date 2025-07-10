using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidad;
using static CapaEntidad.Class1;

namespace CapaLogica
{
    public class VentaBL
    {
        #region Singleton
        private static readonly VentaBL _instancia = new VentaBL();
        public static VentaBL Instancia { get { return _instancia; } }
        #endregion

        #region Métodos

        public bool RegistrarVenta(entVenta venta, out int ventaId, out string mensaje)
        {
            SqlCommand cmd = null;
            SqlConnection cn = null;
            ventaId = 0;
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_RegistrarVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros básicos
                cmd.Parameters.AddWithValue("@ClienteId", venta.Cliente.id_cliente);
                cmd.Parameters.AddWithValue("@UsuarioId", venta.Vendedor.id_usuario);
                cmd.Parameters.AddWithValue("@AlmacenId", venta.AlmacenId);

                // Crear el DataTable con los detalles
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("PresentacionId", typeof(int));
                dtDetalles.Columns.Add("Cantidad", typeof(int));
                dtDetalles.Columns.Add("PrecioUnitario", typeof(decimal));
                dtDetalles.Columns.Add("Descuento", typeof(decimal));
                dtDetalles.Columns.Add("PromocionId", typeof(int));

                foreach (var detalle in venta.Detalles)
                {
                    dtDetalles.Rows.Add(
                        
                        detalle.Cantidad,
                        detalle.PrecioUnitario,
                        detalle.Descuento,
                        detalle.Promocion?.PromocionId ?? 0
                    );
                }

                SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@DetallesVenta", dtDetalles);
                paramDetalles.SqlDbType = SqlDbType.Structured;
                paramDetalles.TypeName = "DetalleVentaType";

                // Parámetros de salida
                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramResultado);

                SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramMensaje);

                SqlParameter paramVentaId = new SqlParameter("@VentaId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramVentaId);

                cn.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToBoolean(paramResultado.Value);
                mensaje = paramMensaje.Value.ToString();
                ventaId = Convert.ToInt32(paramVentaId.Value);
            }
            catch (Exception e)
            {
                mensaje = "Error al registrar venta: " + e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }

        public List<entVenta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return VentaBL.Instancia.ListarVentasPorFecha(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ventas: " + ex.Message);
            }
        }

        public entVenta ObtenerVentaPorId(int ventaId)
        {
            try
            {
                return VentaBL.Instancia.ObtenerVentaPorId(ventaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener venta: " + ex.Message);
            }
        }

        public bool AnularVenta(int ventaId, out string mensaje)
        {
            try
            {
                var venta = VentaBL.Instancia.ObtenerVentaPorId(ventaId);
                if (venta == null || !venta.Estado)
                {
                    mensaje = "La venta no existe o ya está anulada";
                    return false;
                }

                return VentaBL.Instancia.AnularVenta(ventaId, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = "Error al anular venta: " + ex.Message;
                return false;
            }
        }

        #endregion
    }
}
