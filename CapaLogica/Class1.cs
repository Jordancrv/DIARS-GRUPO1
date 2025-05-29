using CapaDatos;
using static CapaEntidad.Class1;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

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
            ventaId = 0;
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Asegúrate de tener este método en tu clase Conexion
                cmd = new SqlCommand("sp_RegistrarVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros básicos
                cmd.Parameters.AddWithValue("@ClienteId", venta.Cliente.ClienteId);
                cmd.Parameters.AddWithValue("@UsuarioId", venta.Vendedor.UsuarioId);
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
                        detalle.Presentacion.PresentacionId,
                        detalle.Cantidad,
                        detalle.PrecioUnitario,
                        detalle.Descuento,
                        detalle.Promocion?.PromocionId ?? 0
                    );
                }

                // Añadir el parámetro tipo tabla
                SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@DetallesVenta", dtDetalles);
                paramDetalles.SqlDbType = SqlDbType.Structured;
                paramDetalles.TypeName = "DetalleVentaType"; // Asegúrate de que este tipo exista en SQL Server

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
            catch (SqlException e)
            {
                mensaje = "Error al registrar venta: " + e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }


        public List<entVenta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return datVenta.Instancia.ListarVentasPorFecha(fechaInicio, fechaFin);
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
                return datVenta.Instancia.ObtenerVentaPorId(ventaId);
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
                // Validar que la venta existe y está activa
                var venta = datVenta.Instancia.ObtenerVentaPorId(ventaId);
                if (venta == null || !venta.Estado)
                {
                    mensaje = "La venta no existe o ya está anulada";
                    return false;
                }

                return datVenta.Instancia.AnularVenta(ventaId, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = "Error al anular venta: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region Métodos Privados
        
        #endregion
    }
}
