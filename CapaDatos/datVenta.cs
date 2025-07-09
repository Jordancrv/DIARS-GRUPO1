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

        //public bool InsertarVenta1(entPedidosVenta pedido, out int pedidoId)
        //{
        //    SqlCommand cmd = null;
        //    pedidoId = 0;
        //    bool resultado = false;

        //    try
        //    {
        //        using (SqlConnection cn = Conexion.Instancia.Conectar())
        //        {
        //            cmd = new SqlCommand("sp_RegistrarPedidoVenta", cn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@id_cliente", pedido.id_cliente);
        //            cmd.Parameters.AddWithValue("@id_usuario", pedido.id_usuario);
        //            cmd.Parameters.AddWithValue("@estado", pedido.estado);

        //            DataTable dtDetalles = new DataTable();
        //            dtDetalles.Columns.Add("id_producto", typeof(int));
        //            dtDetalles.Columns.Add("cantidad", typeof(int));
        //            dtDetalles.Columns.Add("precio_unitario", typeof(decimal));
        //            dtDetalles.Columns.Add("subtotal", typeof(decimal)); // Este campo puede ser eliminado si no se usa en el SP

        //            foreach (var detalle in pedido.Detalles)
        //            {
        //                dtDetalles.Rows.Add(
        //                    detalle.id_producto,
        //                    detalle.cantidad,
        //                    detalle.precio_unitario,
        //                    detalle.subtotal
        //                );
        //            }

        //            SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@Detalles", dtDetalles);
        //            paramDetalles.SqlDbType = SqlDbType.Structured;
        //            paramDetalles.TypeName = "DetallePedidoType";

        //            SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
        //            {
        //                Direction = ParameterDirection.Output
        //            };
        //            cmd.Parameters.Add(paramResultado);

        //            SqlParameter paramPedidoId = new SqlParameter("@PedidoId", SqlDbType.Int)
        //            {
        //                Direction = ParameterDirection.Output
        //            };
        //            cmd.Parameters.Add(paramPedidoId);

        //            cn.Open();
        //            cmd.ExecuteNonQuery();

        //            resultado = Convert.ToBoolean(paramResultado.Value);
        //            pedidoId = Convert.ToInt32(paramPedidoId.Value);
        //        }
        //    }
        //    catch
        //    {
        //        resultado = false;
        //        pedidoId = 0;
        //    }

        //    return resultado;
        //}


        public bool InsertarVenta(entPedidoVenta pedido)
        {
            SqlCommand cmd = null;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("InsertarPedidoVenta", cn); // Asegúrate que el SP se llama así
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cliente", pedido.IdCliente);
                    cmd.Parameters.AddWithValue("@id_usuario", pedido.IdUsuario);
                    cmd.Parameters.AddWithValue("@id_comprobante", pedido.IdComprobante);
                    cmd.Parameters.AddWithValue("@total", pedido.Total);
                    cmd.Parameters.AddWithValue("@total_descuento_productos", pedido.TotalDescuentoProductos);
                    cmd.Parameters.AddWithValue("@total_descuento_promociones", pedido.TotalDescuentoPromociones);
                    cmd.Parameters.AddWithValue("@total_con_descuento", pedido.TotalConDescuento);
                    cmd.Parameters.AddWithValue("@estado", pedido.Estado);

                    // Crear DataTable para detalles
                    DataTable dtDetalles = new DataTable();
                    dtDetalles.Columns.Add("id_producto", typeof(int));
                    dtDetalles.Columns.Add("cantidad", typeof(int));
                    dtDetalles.Columns.Add("precio_unitario", typeof(decimal));
                    dtDetalles.Columns.Add("subtotal", typeof(decimal));
                    dtDetalles.Columns.Add("descuento", typeof(decimal));
                    dtDetalles.Columns.Add("total_con_descuento", typeof(decimal));

                    foreach (var detalle in pedido.Detalles)
                    {
                        dtDetalles.Rows.Add(
                            detalle.IdProducto,
                            detalle.Cantidad,
                            detalle.PrecioUnitario,
                            detalle.Subtotal,
                            detalle.Descuento,
                            detalle.TotalConDescuento
                        );
                    }

                    SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@Detalles", dtDetalles);
                    paramDetalles.SqlDbType = SqlDbType.Structured;
                    paramDetalles.TypeName = "DetalleVentaType"; // Asegúrate que sea el nombre correcto

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar venta: " + ex.Message);
            }

            return resultado;
        }

        public decimal ObtenerDescuentoPromocion(int idProducto)
        {
            decimal descuento = 0;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDescuentoPromocion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                SqlParameter outputParam = new SqlParameter("@descuento", SqlDbType.Decimal);
                outputParam.Precision = 5;
                outputParam.Scale = 2;
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                cn.Open();
                cmd.ExecuteNonQuery();

                if (outputParam.Value != DBNull.Value)
                    descuento = (decimal)outputParam.Value;
            }

            return descuento;
        }



        //public List<entPedidosVenta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        //{
        //    SqlCommand cmd = null;
        //    List<entPedidosVenta> lista = new List<entPedidosVenta>();

        //    try
        //    {
        //        using (SqlConnection cn = Conexion.Instancia.Conectar())
        //        {
        //            cmd = new SqlCommand("sp_ListarVentasPorFecha", cn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
        //            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

        //            cn.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    entPedidosVenta venta = new entPedidosVenta
        //                    {
        //                        id_pedido = Convert.ToInt32(dr["VentaId"]),
        //                        fecha = Convert.ToDateTime(dr["Fecha"]),
        //                        estado = dr["Estado"].ToString(),
        //                        //total = Convert.ToDecimal(dr["Total"]),
        //                        id_cliente = Convert.ToInt32(dr["ClienteId"]),
        //                        Cliente = new entClientes
        //                        {
        //                            id_cliente = Convert.ToInt32(dr["ClienteId"]),
        //                            razon_social = dr["RazonSocial"].ToString()
        //                        }
        //                    };

        //                    lista.Add(venta);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        throw new Exception("Error al listar ventas: " + e.Message);
        //    }

        //    return lista;
        //}



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
                                //total = Convert.ToDecimal(dr["total"]),
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString(),
                                    ruc = dr["ruc"].ToString(),
                                    direccion = dr["direccion"].ToString(),
                                    //telefono = dr["telefono"].ToString(),
                                    // email = dr["email"].ToString(),
                                    activo = Convert.ToBoolean(dr["activo"])
                                }
                            };
                        }

                        if (pedido != null)
                        {
                            dr.NextResult();
                            pedido.Detalles = new List<entDetallesVenta>();

                            while (dr.Read())
                            {
                                pedido.Detalles.Add(new entDetallesVenta
                                {
                                    id_detalle = Convert.ToInt32(dr["id_detalle"]),
                                    id_producto = Convert.ToInt32(dr["id_producto"]),
                                    cantidad = Convert.ToInt32(dr["cantidad"]),
                                    precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                    //subtotal = Convert.ToDecimal(dr["subtotal"]),
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

        public List<entPedidoVenta> ListarVentas()
        {
            List<entPedidoVenta> lista = new List<entPedidoVenta>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPedidosVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            entPedidoVenta venta = new entPedidoVenta
                            {
                                IdPedidoVenta = Convert.ToInt32(dr["id_pedido"]),
                                Fecha = Convert.ToDateTime(dr["fecha"]),
                                Estado = dr["estado"].ToString(),
                                IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                IdUsuario = dr["id_usuario"] != DBNull.Value ? Convert.ToInt32(dr["id_usuario"]) : 0,
                                IdComprobante = Convert.ToInt32(dr["id_comprobante"]),
                                Total = Convert.ToDecimal(dr["total"]),
                                TotalDescuentoProductos = Convert.ToDecimal(dr["total_descuento_productos"]),
                                TotalDescuentoPromociones = Convert.ToDecimal(dr["total_descuento_promociones"]),
                                TotalConDescuento = Convert.ToDecimal(dr["total_con_descuento"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString()
                                },
                                Detalles = new List<entDetalleVenta>()
                            };

                            // Cargar los detalles de la venta
                            venta.Detalles = ListarDetallesPorVenta(venta.IdPedidoVenta, cn);

                            lista.Add(venta);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al listar ventas: " + ex.Message);
            }

            return lista;
        }




        private List<entDetalleVenta> ListarDetallesPorVenta(int idPedido, SqlConnection cn)
        {
            List<entDetalleVenta> detalles = new List<entDetalleVenta>();

            using (SqlCommand cmd = new SqlCommand("sp_ListarDetallesVentaPorPedido", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDetalleVenta det = new entDetalleVenta
                        {
                            IdDetalle = Convert.ToInt32(dr["id_detalle"]),
                            IdPedido = Convert.ToInt32(dr["id_pedido"]),
                            IdProducto = Convert.ToInt32(dr["id_producto"]),
                            Cantidad = Convert.ToInt32(dr["cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["precio_unitario"]),
                            Subtotal = Convert.ToDecimal(dr["subtotal"]),
                            Descuento = Convert.ToDecimal(dr["descuento"]),
                            TotalConDescuento = Convert.ToDecimal(dr["total_con_descuento"])
                        };

                        detalles.Add(det);
                    }
                }
            }

            return detalles;
        }


        public List<entPedidosVenta> ObtenerVentasPorClienteId(int idCliente)
        {
            SqlCommand cmd = null;
            List<entPedidosVenta> listaVentas = new List<entPedidosVenta>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_ObtenerVentasPorClienteId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new entPedidosVenta
                            {
                                id_pedido = Convert.ToInt32(dr["id_pedido"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                estado = dr["estado"].ToString(),
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString()
                                }
                            };

                            listaVentas.Add(venta);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al buscar ventas por cliente: " + e.Message);
            }

            return listaVentas;
        }


        public bool AnularVenta(int ventaId)
        {
            SqlCommand cmd = null;
            bool resultado = false;

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

                cn.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToBoolean(paramResultado.Value);
            }
            catch (SqlException)
            {
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }


        public entPedidosVenta BuscarVentaPorId(int id_pedido)
        {
            SqlCommand cmd = null;
            entPedidosVenta venta = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_BuscarVentaPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", id_pedido);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new entPedidosVenta
                            {
                                id_pedido = Convert.ToInt32(dr["id_pedido"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                estado = dr["estado"].ToString(),
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString(),
                                    ruc = dr["ruc"].ToString(),
                                    direccion = dr["direccion"].ToString(),
                                    //  telefono = dr["telefono"].ToString(),
                                    //  email = dr["email"].ToString(),
                                    activo = Convert.ToBoolean(dr["activo"])
                                }
                            };
                        }

                        if (venta != null)
                        {
                            dr.NextResult();
                            venta.Detalles = new List<entDetallesVenta>();

                            while (dr.Read())
                            {
                                venta.Detalles.Add(new entDetallesVenta
                                {
                                    id_detalle = Convert.ToInt32(dr["id_detalle"]),
                                    id_producto = Convert.ToInt32(dr["id_producto"]),
                                    cantidad = Convert.ToInt32(dr["cantidad"]),
                                    precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),

                                    Producto = new entProductos
                                    {
                                        id_producto = Convert.ToInt32(dr["id_producto"]),
                                        nombre = dr["nombre_producto"].ToString(),
                                        descripcion = dr["descripcion"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                venta = null;
            }

            return venta;
        }


        public bool EditarVenta(entPedidosVenta pedido)
        {
            SqlCommand cmd = null;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_ActualizarPedidoVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_pedido", pedido.id_pedido);
                    cmd.Parameters.AddWithValue("@id_cliente", pedido.id_cliente);
                    cmd.Parameters.AddWithValue("@estado", pedido.estado);

                    DataTable dtDetalles = new DataTable();
                    dtDetalles.Columns.Add("id_producto", typeof(int));
                    dtDetalles.Columns.Add("cantidad", typeof(int));
                    dtDetalles.Columns.Add("precio_unitario", typeof(decimal));
                    dtDetalles.Columns.Add("subtotal", typeof(decimal));

                    foreach (var detalle in pedido.Detalles)
                    {
                        dtDetalles.Rows.Add(
                            detalle.id_producto,
                            detalle.cantidad,
                            detalle.precio_unitario,
                            detalle.subtotal
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

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(paramResultado.Value);
                }
            }
            catch (SqlException)
            {
                resultado = false;
            }

            return resultado;
        }


        public bool InsertarComprobante(entComprobantePago comprobante)
        {
            SqlCommand cmd = null;
            bool insertado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarComprobante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tipo", comprobante.tipo);
                cmd.Parameters.AddWithValue("@serie", comprobante.serie ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@numero", comprobante.numero ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@activo", comprobante.activo); // Nuevo parámetro


                cn.Open();
                insertado = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al insertar comprobante: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return insertado;
        }

        public List<entComprobantePago> ListarComprobantes()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<entComprobantePago> lista = new List<entComprobantePago>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ListarComprobante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entComprobantePago comprobante = new entComprobantePago
                    {
                        tipo = dr["tipo"].ToString(),
                        serie = dr["serie"] != DBNull.Value ? dr["serie"].ToString() : null,
                        numero = dr["numero"] != DBNull.Value ? dr["numero"].ToString() : null,
                        activo = dr["activo"] != DBNull.Value ? Convert.ToBoolean(dr["activo"]) : false
                    };

                    lista.Add(comprobante);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al listar comprobantes: " + e.Message, e);
            }
            finally
            {
                dr?.Close();
                cmd?.Connection?.Close();
            }

            return lista;
        }







        #endregion Métodos

    }























}