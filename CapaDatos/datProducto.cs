﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class datProducto
    {
        #region singleton
        private static readonly datProducto _instancia = new datProducto();
        public static datProducto Instancia
        {
            get { return datProducto._instancia; }
        }
        #endregion singleton

        #region métodos

        public List<entProductos> ListarProductos()
        {
            SqlCommand cmd = null;
            List<entProductos> lista = new List<entProductos>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ListarProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entProductos p = new entProductos
                    {
                        id_producto = Convert.ToInt32(dr["id_producto"]),
                        codigo = dr["codigo"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        precio = Convert.ToDecimal(dr["precio"]),
                        precioventa = dr["precioventa"] != DBNull.Value ? Convert.ToDecimal(dr["precioventa"]) : 0m,
                        stock = Convert.ToInt32(dr["stock"]),
                        stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                        unidad_medida = dr["unidad_medida"].ToString(),
                        id_proveedor = dr["id_proveedor"] != DBNull.Value ? Convert.ToInt32(dr["id_proveedor"]) : 0,
                        idCategoria = dr["idCategoria"] != DBNull.Value ? Convert.ToInt32(dr["idCategoria"]) : 0,
                        idPresentacion = dr["idPresentacion"] != DBNull.Value ? Convert.ToInt32(dr["idPresentacion"]) : 0,
                        idTipoEmpaque = dr["idTipoEmpaque"] != DBNull.Value ? Convert.ToInt32(dr["idTipoEmpaque"]) : 0,
                        activo = Convert.ToBoolean(dr["activo"]),
                        imagen_url = dr["imagen_url"]?.ToString(),

                        // Propiedades de navegación
                        nombreProveedor = dr["nombreProveedor"]?.ToString(),
                        nombreCategoria = dr["nombreCategoria"]?.ToString(),
                        nombrePresentacion = dr["nombrePresentacion"]?.ToString(),
                        nombreTipoEmpaque = dr["nombreTipoEmpaque"]?.ToString()
                    };

                    lista.Add(p);
                }

                dr.Close();
            }
            catch (SqlException e)
            {
                throw new Exception("Error al listar productos: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return lista;
        }

        public bool InsertarProducto(entProductos producto)
        {
            SqlCommand cmd = null;
            bool insertado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", producto.codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@precio", producto.precio);
                cmd.Parameters.AddWithValue("@precioventa", producto.precioventa);
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@stock_minimo", producto.stock_minimo);
                cmd.Parameters.AddWithValue("@unidad_medida", producto.unidad_medida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);
                cmd.Parameters.AddWithValue("@idCategoria", producto.idCategoria);
                cmd.Parameters.AddWithValue("@idPresentacion", producto.idPresentacion);
                cmd.Parameters.AddWithValue("@idTipoEmpaque", producto.idTipoEmpaque);
                cmd.Parameters.AddWithValue("@activo", producto.activo);
                cmd.Parameters.AddWithValue("@imagen_url", producto.imagen_url ?? (object)DBNull.Value);

                cn.Open();
                insertado = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al insertar producto: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return insertado;
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


        public entProductos BuscarProductoPorId(int id)
        {
            entProductos p = null;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        p = new entProductos
                        {
                            id_producto = Convert.ToInt32(dr["id_producto"]),
                            codigo = dr["codigo"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            precio = Convert.ToDecimal(dr["precio"]),
                            precioventa = Convert.ToDecimal(dr["precioventa"]),
                            stock = Convert.ToInt32(dr["stock"]),
                            stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                            unidad_medida = dr["unidad_medida"].ToString(),
                            id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
                            idCategoria = Convert.ToInt32(dr["idCategoria"]),
                            idPresentacion = Convert.ToInt32(dr["idPresentacion"]),
                            idTipoEmpaque = Convert.ToInt32(dr["idTipoEmpaque"]),
                            activo = Convert.ToBoolean(dr["activo"]),
                            imagen_url = dr["imagen_url"].ToString()
                        };
                    }
                }
            }

            return p;
        }

        public bool EliminarProducto(int id_producto)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public int ObtenerStockMinimo(int idProducto)
        {
            int stockMinimo = 0;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerStockMinimo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    stockMinimo = Convert.ToInt32(result);
            }
            return stockMinimo;
        }

        #endregion
    }
}
