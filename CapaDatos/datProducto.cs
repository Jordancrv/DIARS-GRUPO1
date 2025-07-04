using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        stock = Convert.ToInt32(dr["stock"]),
                        stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                        unidad_medida = dr["unidad_medida"].ToString(),
                        activo = Convert.ToBoolean(dr["activo"]),

                        // **CORRECCIÓN:** Estas líneas se eliminan porque el SP no devuelve los IDs.
                        // Si estas propiedades (id_proveedor, idCategoria, etc.) son estrictamente necesarias
                        // en tu entidad y el SP no las devuelve, entonces DEBES modificar el SP.
                        // De lo contrario, no puedes mapearlas desde el DataReader.
                        // id_proveedor = dr["proveedor"] != DBNull.Value ? 0 : 0, // No se devuelve el id, solo el nombre
                        // idCategoria = dr["nombreCategoria"] != DBNull.Value ? 0 : 0,
                        // idPresentacion = dr["nombrePresentacion"] != DBNull.Value ? 0 : 0,
                        // idTipoEmpaque = dr["nombreEmpaque"] != DBNull.Value ? 0 : 0,

                        // Propiedades de navegación adaptadas al SP
                        nombreProveedor = dr["proveedor"]?.ToString(),
                        nombreCategoria = dr["nombreCategoria"]?.ToString(),
                        nombrePresentacion = dr["nombrePresentacion"]?.ToString(),
                        nombreTipoEmpaque = dr["nombreEmpaque"]?.ToString(),
                        // materialEmpaque (del SP) NO SE AGREGA para ser "similar" y no agregar extras
                    };

                    lista.Add(p);
                }

                dr.Close();
            }
            catch (SqlException e)
            {
                // Manejo de errores simplificado, similar a tu original
                throw new Exception("Error al listar productos: " + e.Message, e);
            }
            finally
            {
                // Asegura que la conexión se cierre correctamente
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
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@stock_minimo", producto.stock_minimo);
                cmd.Parameters.AddWithValue("@unidad_medida", producto.unidad_medida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);
                cmd.Parameters.AddWithValue("@idCategoria", producto.idCategoria);
                cmd.Parameters.AddWithValue("@idPresentacion", producto.idPresentacion);
                cmd.Parameters.AddWithValue("@idTipoEmpaque", producto.idTipoEmpaque);
                cmd.Parameters.AddWithValue("@activo", producto.activo);

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

        public bool EditarProducto(entProductos producto)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EditarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_producto", producto.id_producto);
                cmd.Parameters.AddWithValue("@codigo", producto.codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@precio", producto.precio);
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@stock_minimo", producto.stock_minimo);
                cmd.Parameters.AddWithValue("@unidad_medida", producto.unidad_medida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);
                cmd.Parameters.AddWithValue("@idCategoria", producto.idCategoria);
                cmd.Parameters.AddWithValue("@idPresentacion", producto.idPresentacion);
                cmd.Parameters.AddWithValue("@idTipoEmpaque", producto.idTipoEmpaque);
                cmd.Parameters.AddWithValue("@activo", producto.activo);

                cn.Open();
                editado = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al editar producto: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return editado;
        }

        public entProductos BuscarProducto(int id_producto)
        {
            SqlCommand cmd = null;
            entProductos producto = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_BuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    producto = new entProductos
                    {
                        id_producto = Convert.ToInt32(dr["id_producto"]),
                        codigo = dr["codigo"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        precio = Convert.ToDecimal(dr["precio"]),
                        stock = Convert.ToInt32(dr["stock"]),
                        stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                        unidad_medida = dr["unidad_medida"].ToString(),
                        id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
                        idCategoria = Convert.ToInt32(dr["idCategoria"]),
                        idPresentacion = Convert.ToInt32(dr["idPresentacion"]),
                        idTipoEmpaque = Convert.ToInt32(dr["idTipoEmpaque"]),
                        activo = Convert.ToBoolean(dr["activo"]),

                        // Propiedades de navegación
                        nombreProveedor = dr["nombreProveedor"]?.ToString(),
                        nombreCategoria = dr["nombreCategoria"]?.ToString(),
                        nombrePresentacion = dr["nombrePresentacion"]?.ToString(),
                        nombreTipoEmpaque = dr["nombreTipoEmpaque"]?.ToString()
                    };
                }

                dr.Close();
            }
            catch (SqlException e)
            {
                throw new Exception("Error al buscar producto: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return producto;
        }


        public bool EliminarProducto(int id_producto)
        {
            SqlCommand cmd = null;
            bool eliminado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);

                cn.Open();
                eliminado = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al eliminar producto: " + e.Message, e);
            }
            finally
            {
                cmd?.Connection?.Close();
            }

            return eliminado;
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

