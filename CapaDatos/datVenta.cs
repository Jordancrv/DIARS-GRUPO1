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


        public bool InsertarVenta(entPedidoVenta pedido)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("InsertarPedidoVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cliente", pedido.IdCliente);
                    cmd.Parameters.AddWithValue("@id_usuario", pedido.IdUsuario);
                    cmd.Parameters.AddWithValue("@id_comprobante", pedido.IdComprobante);
                    cmd.Parameters.AddWithValue("@total", pedido.Total);
                    cmd.Parameters.AddWithValue("@total_descuento_productos", pedido.TotalDescuentoProductos);
                    cmd.Parameters.AddWithValue("@total_descuento_promociones", pedido.TotalDescuentoPromociones);
                    cmd.Parameters.AddWithValue("@total_con_descuento", pedido.TotalConDescuento);
                    cmd.Parameters.AddWithValue("@estado", pedido.Estado);
                    cmd.Parameters.AddWithValue("@fecha", pedido.Fecha);

                    // Detalles
                    DataTable tablaDetalles = new DataTable();
                    tablaDetalles.Columns.Add("id_producto", typeof(int));
                    tablaDetalles.Columns.Add("cantidad", typeof(int));
                    tablaDetalles.Columns.Add("precio_unitario", typeof(decimal));
                    tablaDetalles.Columns.Add("subtotal", typeof(decimal));
                    tablaDetalles.Columns.Add("descuento", typeof(decimal));
                    tablaDetalles.Columns.Add("total_con_descuento", typeof(decimal));

                    foreach (var item in pedido.Detalles)
                    {
                        tablaDetalles.Rows.Add(item.IdProducto, item.Cantidad, item.PrecioUnitario,
                                               item.Subtotal, item.Descuento, item.TotalConDescuento);
                    }

                    SqlParameter pDetalles = cmd.Parameters.AddWithValue("@Detalles", tablaDetalles);
                    pDetalles.SqlDbType = SqlDbType.Structured;
                    pDetalles.TypeName = "DetalleVentaType";

                    cn.Open();
                    object result = cmd.ExecuteScalar(); // <- captura el ID retornado por el SP
                    if (result != null)
                    {
                        pedido.IdPedidoVenta = Convert.ToInt32(result);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar venta: " + ex.Message);
            }
        }


        public entPedidoVenta BuscarVentaPorId(int id_pedido)
        {
            SqlCommand cmd = null;
            entPedidoVenta venta = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("sp_ObtenerPedidoPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", id_pedido);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new entPedidoVenta
                            {
                                IdPedidoVenta = Convert.ToInt32(dr["id_pedido"]),
                                Fecha = Convert.ToDateTime(dr["fecha"]),
                                Estado = dr["estado"].ToString(),
                                Total = Convert.ToDecimal(dr["total"]),
                                TotalDescuentoProductos = Convert.ToDecimal(dr["total_descuento_productos"]),
                                TotalDescuentoPromociones = Convert.ToDecimal(dr["total_descuento_promociones"]),
                                TotalConDescuento = Convert.ToDecimal(dr["total_con_descuento"]),

                                // 👇 Agrega aquí:
                                EsDelivery = Convert.ToBoolean(dr["es_delivery"]),

                                IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                Cliente = new entClientes
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                    razon_social = dr["razon_social"].ToString(),
                                    ruc = dr["ruc"].ToString(),
                                    direccion = dr["direccion"].ToString(),
                                    activo = Convert.ToBoolean(dr["cliente_activo"])
                                },

                                Comprobante = new entComprobantePago
                                {
                                    id_comprobante = Convert.ToInt32(dr["id_comprobante"]),
                                    tipo = dr["tipo"].ToString(),
                                    serie = dr["serie"].ToString(),
                                    numero = dr["numero"].ToString()
                                },

                                Usuario = new entUsuario
                                {
                                    id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                    rol = dr["rol"].ToString()
                                }
                            };
                        }


                        if (venta != null)
                        {
                            dr.NextResult();
                            venta.Detalles = new List<entDetalleVenta>();

                            while (dr.Read())
                            {
                                venta.Detalles.Add(new entDetalleVenta
                                {
                                    IdProducto = Convert.ToInt32(dr["id_producto"]),
                                    Cantidad = Convert.ToInt32(dr["cantidad"]),
                                    PrecioUnitario = Convert.ToDecimal(dr["precio_unitario"]),
                                    Subtotal = Convert.ToDecimal(dr["subtotal"]),
                                    Descuento = Convert.ToDecimal(dr["descuento"]),
                                    TotalConDescuento = Convert.ToDecimal(dr["total_con_descuento"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar venta por ID: " + ex.Message);
            }

            return venta;
        }



        public List<entPedidoVenta> ListarPedidosProcesados()
        {
            List<entPedidoVenta> lista = new List<entPedidoVenta>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPedidosCompleto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new entPedidoVenta
                            {
                                IdPedidoVenta = dr["id_pedido"] != DBNull.Value ? Convert.ToInt32(dr["id_pedido"]) : 0,
                                IdCliente = dr["id_cliente"] != DBNull.Value ? Convert.ToInt32(dr["id_cliente"]) : 0,
                                IdUsuario = dr["id_usuario"] != DBNull.Value ? Convert.ToInt32(dr["id_usuario"]) : 0,
                                Fecha = dr["fecha"] != DBNull.Value ? Convert.ToDateTime(dr["fecha"]) : DateTime.MinValue,
                                IdComprobante = dr["id_comprobante"] != DBNull.Value ? Convert.ToInt32(dr["id_comprobante"]) : 0,
                                Total = dr["total"] != DBNull.Value ? Convert.ToDecimal(dr["total"]) : 0,
                                TotalDescuentoProductos = dr["total_descuento_productos"] != DBNull.Value ? Convert.ToDecimal(dr["total_descuento_productos"]) : 0,
                                TotalDescuentoPromociones = dr["total_descuento_promociones"] != DBNull.Value ? Convert.ToDecimal(dr["total_descuento_promociones"]) : 0,
                                TotalConDescuento = dr["total_con_descuento"] != DBNull.Value ? Convert.ToDecimal(dr["total_con_descuento"]) : 0,
                                Estado = dr["estado"] != DBNull.Value ? dr["estado"].ToString() : string.Empty
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al listar pedidos procesados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar pedidos procesados: " + ex.Message);
            }

            return lista;
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


        private List<entDetalleVenta> ListarDetallesPorVenta(int idPedido, SqlConnection cn)
        {
            List<entDetalleVenta> detalles = new List<entDetalleVenta>();

            using (SqlCommand cmd = new SqlCommand("sp_ListarDetallesVentaPorPedido", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                // Aquí se abre el segundo DataReader, pero solo si el primero ya se cerró
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


        // *** MÉTODO ListarVentas MODIFICADO PARA USAR LA OPCIÓN 2 ***
        public List<entPedidoVenta> ListarVentas()
        {
            List<entPedidoVenta> listaVentasFinal = new List<entPedidoVenta>(); // Esta será la lista final con detalles
            List<entPedidoVenta> ventasSinDetalles = new List<entPedidoVenta>(); // Lista temporal para las ventas principales

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPedidosVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) // Primer DataReader abierto
                    {
                        // Paso 1: Leer TODAS las ventas principales y almacenarlas temporalmente.
                        // El DataReader (dr) permanece abierto solo durante este bucle.
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
                                Cliente = new entClientes // Asumo que necesitas cargar el objeto cliente aquí
                                {
                                    id_cliente = Convert.ToInt32(dr["id_cliente"])
                                    // Si hay más propiedades de cliente que vienen de sp_ListarPedidosVenta, cárgalas aquí
                                    // ejemplo: nombres = dr["nombre_cliente"].ToString()
                                },
                                // No inicializamos Detalles aquí, lo haremos en el segundo bucle
                                Detalles = new List<entDetalleVenta>() // Aunque se asignará después, es buena práctica inicializar
                            };
                            ventasSinDetalles.Add(venta);
                        }
                    } // CIERRE CRÍTICO: El primer SqlDataReader (dr) se cierra aquí al salir del bloque 'using'.

                    // Paso 2: Ahora que el primer DataReader está cerrado y la conexión está libre,
                    // iteramos sobre la lista temporal para cargar los detalles.
                    foreach (var venta in ventasSinDetalles)
                    {
                        // Aquí llamamos a ListarDetallesPorVenta.
                        // Como el DataReader anterior ya está cerrado, este nuevo ExecuteReader
                        // en ListarDetallesPorVenta puede ejecutarse sin conflicto en la misma conexión 'cn'.
                        venta.Detalles = ListarDetallesPorVenta(venta.IdPedidoVenta, cn);
                        listaVentasFinal.Add(venta); // Añadir a la lista final
                    }
                } // La conexión 'cn' se cierra aquí al salir del bloque 'using'.
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al listar ventas: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar ventas: " + ex.Message);
            }

            return listaVentasFinal;
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

        public bool EditarProducto(entProductos p)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_producto", p.id_producto);
                cmd.Parameters.AddWithValue("@codigo", p.codigo);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@precio", p.precio);
                cmd.Parameters.AddWithValue("@precioventa", p.precioventa);
                cmd.Parameters.AddWithValue("@stock", p.stock);
                cmd.Parameters.AddWithValue("@stock_minimo", p.stock_minimo);
                cmd.Parameters.AddWithValue("@unidad_medida", p.unidad_medida);
                cmd.Parameters.AddWithValue("@id_proveedor", p.id_proveedor);
                cmd.Parameters.AddWithValue("@idCategoria", p.idCategoria);
                cmd.Parameters.AddWithValue("@idPresentacion", p.idPresentacion);
                cmd.Parameters.AddWithValue("@idTipoEmpaque", p.idTipoEmpaque);
                cmd.Parameters.AddWithValue("@activo", p.activo);
                cmd.Parameters.AddWithValue("@imagen_url", p.imagen_url);

                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
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
        public List<(string Mes, decimal TotalVentas)> ObtenerResumenVentasMensual()
        {
            List<(string Mes, decimal TotalVentas)> resumen = new List<(string, decimal)>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ResumenVentasPorMes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string mes = dr["Mes"].ToString();
                        decimal total = Convert.ToDecimal(dr["TotalVentas"]);
                        resumen.Add((mes, total));
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al obtener resumen de ventas mensual: " + e.Message, e);
            }

            return resumen;
        }

        public bool InsertarPedidoVenta(entPedidoVenta pedido)
        {
            bool resultado = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("InsertarPedidoVenta", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros simples
                cmd.Parameters.AddWithValue("@id_cliente", pedido.IdCliente);
                cmd.Parameters.AddWithValue("@id_usuario", pedido.IdUsuario);
                cmd.Parameters.AddWithValue("@id_comprobante", pedido.IdComprobante);
                cmd.Parameters.AddWithValue("@total", pedido.Total);
                cmd.Parameters.AddWithValue("@total_descuento_productos", pedido.TotalDescuentoProductos);
                cmd.Parameters.AddWithValue("@total_descuento_promociones", pedido.TotalDescuentoPromociones);
                cmd.Parameters.AddWithValue("@total_con_descuento", pedido.TotalConDescuento);
                cmd.Parameters.AddWithValue("@estado", pedido.Estado);

                // Tipo tabla: Detalles
                DataTable detalles = new DataTable();
                detalles.Columns.Add("id_producto", typeof(int));
                detalles.Columns.Add("cantidad", typeof(int));
                detalles.Columns.Add("precio_unitario", typeof(decimal));
                detalles.Columns.Add("subtotal", typeof(decimal));
                detalles.Columns.Add("descuento", typeof(decimal));
                detalles.Columns.Add("total_con_descuento", typeof(decimal));

                foreach (var item in pedido.Detalles)
                {
                    detalles.Rows.Add(item.IdProducto, item.Cantidad, item.PrecioUnitario, item.Subtotal, item.Descuento, item.TotalConDescuento);
                }

                SqlParameter detallesParam = cmd.Parameters.AddWithValue("@Detalles", detalles);
                detallesParam.SqlDbType = SqlDbType.Structured;
                detallesParam.TypeName = "DetalleVentaType";

                cn.Open();
                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;


        }

        public decimal ObtenerDescuentoPromocion(int idProducto)
        {
            decimal descuento = 0;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerDescuentoPromocion", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                SqlParameter output = new SqlParameter("@descuento", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output,
                    Precision = 5,
                    Scale = 2
                };
                cmd.Parameters.Add(output);

                cn.Open();
                cmd.ExecuteNonQuery();

                if (output.Value != DBNull.Value)
                {
                    descuento = Convert.ToDecimal(output.Value);
                }
            }

            return descuento;
        }
        #endregion Métodos

    }
}