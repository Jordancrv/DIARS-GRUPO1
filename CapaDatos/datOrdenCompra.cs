using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class datOrdenCompra
    {
        #region Singleton
        private static readonly datOrdenCompra _instancia = new datOrdenCompra();
        public static datOrdenCompra Instancia => _instancia;
        #endregion

        public bool InsertarOrdenCompraValidada(OrdenCompra orden)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("sp_InsertarOrdenCompraValidada", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_proveedor", orden.id_proveedor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_usuario", orden.id_usuario);
                    cmd.Parameters.AddWithValue("@tipo_orden", orden.tipo_orden);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id_producto", typeof(int));
                    dt.Columns.Add("cantidad", typeof(int));
                    dt.Columns.Add("precio_unitario", typeof(decimal));
                    foreach (var d in orden.detalles)
                    {
                        dt.Rows.Add(d.id_producto, d.cantidad, d.precio_unitario);
                    }

                    SqlParameter pDetalles = cmd.Parameters.AddWithValue("@detalles", dt);
                    pDetalles.SqlDbType = SqlDbType.Structured;
                    pDetalles.TypeName = "dbo.DetalleOrdenCompraTableType";

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


        public bool AnularOrdenCompra(int idOrdenCompra)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("sp_AnularOrdenCompra", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_orden_compra", idOrdenCompra);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<OrdenCompra> ListarOrdenesCompra()
        {
            List<OrdenCompra> lista = new List<OrdenCompra>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarOrdenesCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    OrdenCompra oc = new OrdenCompra
                    {
                        id_orden_compra = Convert.ToInt32(dr["id_orden_compra"]),
                        id_proveedor = dr["id_proveedor"] != DBNull.Value ? (int?)Convert.ToInt32(dr["id_proveedor"]) : null,
                        id_usuario = Convert.ToInt32(dr["id_usuario"]),
                        fecha = Convert.ToDateTime(dr["fecha"]),
                        estado = dr["estado"].ToString(),
                        total = Convert.ToDecimal(dr["total"]),
                        tipo_orden = dr["tipo_orden"].ToString()
                    };
                    lista.Add(oc);
                }
            }
            return lista;
        }
        public int RegistrarPagoOrden(entPagoOrdenCompra pago)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarPagoOrden", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdOrdenCompra", pago.IdOrdenCompra);
                    cmd.Parameters.AddWithValue("@IdMetodoPago", pago.IdMetodoPago);
                    cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                    cmd.Parameters.AddWithValue("@TipoComprobante", pago.TipoComprobante ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Serie", pago.Serie ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Numero", pago.Numero ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observaciones", pago.Observaciones ?? (object)DBNull.Value);

                    SqlParameter output = new SqlParameter("@IdComprobanteGenerado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)output.Value;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar el pago: " + ex.Message);
            }
        }
        public entPagoOrdenCompra ObtenerPagoPorComprobante(int idComprobante)
        {
            entPagoOrdenCompra pago = null;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM PagosOrdenCompra 
                                             WHERE id_comprobante = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", idComprobante);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        pago = new entPagoOrdenCompra
                        {
                            IdPago = Convert.ToInt32(dr["id_pago"]),
                            IdOrdenCompra = Convert.ToInt32(dr["id_orden_compra"]),
                            IdMetodoPago = Convert.ToInt32(dr["id_metodo_pago"]),
                            IdComprobante = Convert.ToInt32(dr["id_comprobante"]),
                            Monto = Convert.ToDecimal(dr["monto"]),
                            FechaPago = Convert.ToDateTime(dr["fecha_pago"]),
                            Estado = dr["estado"].ToString(),
                            Observaciones = dr["observaciones"]?.ToString()
                        };
                    }
                }
            }

            return pago;
        }

        public bool AnularPagoOrden(int idComprobante)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("sp_AnularPagoOrden", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", idComprobante);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }










        public OrdenCompra ObtenerOrdenCompraPorId(int id)
        {
            OrdenCompra orden = null;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // Obtener datos generales de la orden
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerOrdenCompraPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_orden_compra", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orden = new OrdenCompra
                            {
                                id_orden_compra = Convert.ToInt32(dr["id_orden_compra"]),
                                id_proveedor = dr["id_proveedor"] != DBNull.Value ? (int?)Convert.ToInt32(dr["id_proveedor"]) : null,
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                estado = dr["estado"].ToString(),
                                total = Convert.ToDecimal(dr["total"]),
                                tipo_orden = dr["tipo_orden"].ToString(),
                                detalles = new List<entDetalleOrdenCompra>()  // inicializamos la lista
                            };
                        }
                    }

                    cn.Close();
                }

                if (orden != null)
                {
                    // Obtener detalles de la orden
                    using (SqlCommand cmdDetalle = new SqlCommand("SELECT * FROM DetallesOrdenCompra WHERE id_orden_compra = @id_orden_compra", cn))
                    {
                        cmdDetalle.Parameters.AddWithValue("@id_orden_compra", id);
                        cn.Open();
                        using (SqlDataReader drDetalle = cmdDetalle.ExecuteReader())
                        {
                            while (drDetalle.Read())
                            {
                                var detalle = new entDetalleOrdenCompra
                                {
                                    id_detalle = Convert.ToInt32(drDetalle["id_detalle"]),
                                    id_orden_compra = Convert.ToInt32(drDetalle["id_orden_compra"]),
                                    id_producto = Convert.ToInt32(drDetalle["id_producto"]),
                                    cantidad = Convert.ToInt32(drDetalle["cantidad"]),
                                    precio_unitario = Convert.ToDecimal(drDetalle["precio_unitario"])
                                    // El subtotal ya se calcula en la propiedad de la entidad
                                };
                                orden.detalles.Add(detalle);
                            }
                        }
                    }
                }
            }

            return orden;
        }




    }
}
