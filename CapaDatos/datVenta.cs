using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using CapaEntidad;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using static CapaEntidad.Class1;

namespace CapaDatos
{
    public class datVenta
    {
        #region Singleton
        private static readonly datVenta UnicaInstancia = new datVenta();
        public static datVenta Instancia
        {
            get { return datVenta.UnicaInstancia; }
        }
        #endregion Singleton

        #region Métodos

        public bool RegistrarVenta(entPedidosVenta pedido, out int pedidoId, out string mensaje)
        {
            SqlCommand cmd = null;
            pedidoId = 0;
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_RegistrarPedidoVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cliente", pedido.id_cliente);
                    cmd.Parameters.AddWithValue("@id_usuario", pedido.id_usuario);
                    cmd.Parameters.AddWithValue("@total", pedido.total); 

                    DataTable dtDetalles = new DataTable();
                    dtDetalles.Columns.Add("id_producto", typeof(int));
                    dtDetalles.Columns.Add("cantidad", typeof(int));
                    dtDetalles.Columns.Add("precio_unitario", typeof(decimal));

                    foreach (var detalle in pedido.Detalles)
                    {
                        dtDetalles.Rows.Add(
                            detalle.id_producto,
                            detalle.cantidad,
                            detalle.precio_unitario
                        );
                    }

                    SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@Detalles", dtDetalles);
                    paramDetalles.SqlDbType = SqlDbType.Structured;
                    paramDetalles.TypeName = "DetallePedidoType"; 

                    SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramResultado);

                    SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramMensaje);

                    SqlParameter paramPedidoId = new SqlParameter("@PedidoId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramPedidoId);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(paramResultado.Value);
                    mensaje = paramMensaje.Value.ToString();
                    pedidoId = Convert.ToInt32(paramPedidoId.Value);
                }
            }
            catch (SqlException ex)
            {
                mensaje = $"Error SQL: {ex.Message}";
                resultado = false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error general: {ex.Message}";
                resultado = false;
            }

            return resultado;
        }


        public List<entPedidosVenta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand cmd = null;
            List<entPedidosVenta> lista = new List<entPedidosVenta>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_ListarVentasPorFecha", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            entPedidosVenta venta = new entPedidosVenta
                            {
                                id_pedido = Convert.ToInt32(dr["VentaId"]),
                                fecha = Convert.ToDateTime(dr["Fecha"]),
                                estado = dr["Estado"].ToString(),
                                total = Convert.ToDecimal(dr["Total"]),
                                id_cliente = Convert.ToInt32(dr["ClienteId"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["ClienteId"]),
                                    razon_social = dr["RazonSocial"].ToString()
                                }
                            };

                            lista.Add(venta);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al listar ventas: " + e.Message);
            }

            return lista;
        }



        public entPedidosVenta ObtenerVentaPorId(int idPedido)
        {
            SqlCommand cmd = null;
            entPedidosVenta pedido = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_ObtenerVentaPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pedido = new entPedidosVenta
                            {
                                id_pedido = Convert.ToInt32(dr["id_pedido"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                estado = dr["estado"].ToString(),
                                total = Convert.ToDecimal(dr["total"]),
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString(),
                                    ruc = dr["ruc"].ToString(),
                                    direccion = dr["direccion"].ToString(),
                                    telefono = dr["telefono"].ToString(),
                                    email = dr["email"].ToString(),
                                    activo = Convert.ToBoolean(dr["activo"])
                                }
                            };
                        }

                        if (pedido != null)
                        {
                            dr.NextResult();
                            pedido.Detalles = new List<entDetallesPedido>();

                            while (dr.Read())
                            {
                                pedido.Detalles.Add(new entDetallesPedido
                                {
                                    id_detalle = Convert.ToInt32(dr["id_detalle"]),
                                    id_producto = Convert.ToInt32(dr["id_producto"]),
                                    cantidad = Convert.ToInt32(dr["cantidad"]),
                                    precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                    subtotal = Convert.ToDecimal(dr["subtotal"]),
                                    Producto = new entProductos
                                    {
                                        id_producto = Convert.ToInt32(dr["id_producto"]),
                                        nombre = dr["nombre_producto"].ToString(),
                                        descripcion = dr["descripcion"].ToString()
                                        // Puedes agregar más campos si tienes
                                    }
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al obtener venta por ID: " + e.Message);
            }

            return pedido;
        }



        public bool AnularVenta(int ventaId, out string mensaje)
        {
            SqlCommand cmd = null;
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_AnularVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VentaId", ventaId);
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

                cn.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToBoolean(paramResultado.Value);
                mensaje = paramMensaje.Value.ToString();
            }
            catch (SqlException e)
            {
                mensaje = "Error al anular venta: " + e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }


        #endregion Métodos
       
    }
}