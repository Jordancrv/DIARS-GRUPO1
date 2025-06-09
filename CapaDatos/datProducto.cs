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
                cmd = new SqlCommand("spListarProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entProductos p = new entProductos();
               
                    p.codigo = dr["codigo"].ToString();
                    p.nombre = dr["nombre"].ToString();
                    p.descripcion = dr["descripcion"].ToString();
                    p.precio = Convert.ToDecimal(dr["precio"]);
                    p.stock = Convert.ToInt32(dr["stock"]);
                    p.stock_minimo = Convert.ToInt32(dr["stock_minimo"]);
                    p.unidad_medida = dr["unidad_medida"].ToString();
                    p.id_proveedor = Convert.ToInt32(dr["id_proveedor"]);
                    p.activo = Convert.ToBoolean(dr["activo"]);

                    lista.Add(p);
                }
                dr.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return lista;
        }

        public bool InsertarProducto(entProductos producto)
        {
            SqlCommand cmd = null;
            bool inserto = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", producto.codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@precio", producto.precio);
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@stock_minimo", producto.stock_minimo);
                cmd.Parameters.AddWithValue("@unidad_medida", producto.unidad_medida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor); 
                cmd.Parameters.AddWithValue("@activo", producto.activo);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                inserto = filas > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al insertar producto: " + e.Message, e);
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return inserto;
        }

        public bool EditarProducto(entProductos producto)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarProducto", cn);
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
                cmd.Parameters.AddWithValue("@activo", producto.activo);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                editado = filas > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al editar producto: " + e.Message, e);
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
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
                cmd = new SqlCommand("spBuscarProductoPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    producto = new entProductos()
                    {
                        id_producto = Convert.ToInt32(dr["id_producto"]),
                        codigo = dr["codigo"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        precio = Convert.ToDecimal(dr["precio"]),
                        stock = Convert.ToInt32(dr["stock"]),
                        stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                        unidad_medida = dr["unidad_medida"].ToString(),
                        id_proveedor =  Convert.ToInt32(dr["id_proveedor"]),
                        activo = Convert.ToBoolean(dr["activo"])
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
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
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
                cmd = new SqlCommand("spEliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);

                cn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                eliminado = filasAfectadas > 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Error al eliminar producto: " + e.Message, e);
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return eliminado;
        }

        #endregion















    }
}
