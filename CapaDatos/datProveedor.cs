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
    public class datProveedor
    {

        #region Singleton
        private static readonly datProveedor _instancia = new datProveedor();
        public static datProveedor Instancia
        {
            get { return _instancia; }
        }
        #endregion

        public List<entProveedores> ListarProveedores()
        {
            List<entProveedores> lista = new List<entProveedores>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProveedores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedores prov = new entProveedores
                    {
                        id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
                        razon_social = dr["razon_social"].ToString(),
                        ruc = dr["ruc"].ToString(),
                        direccion = dr["direccion"].ToString(),
                        contacto = dr["contacto"].ToString(),
                        activo = Convert.ToBoolean(dr["activo"])
                    };
                    lista.Add(prov);
                }
            }
            return lista;
        }

        public bool InsertarProveedor(entProveedores proveedor)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razon_social", proveedor.razon_social);
                cmd.Parameters.AddWithValue("@ruc", proveedor.ruc);
                cmd.Parameters.AddWithValue("@direccion", proveedor.direccion);
                cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                cmd.Parameters.AddWithValue("@activo", proveedor.activo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EditarProveedor(entProveedores proveedor)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedor", proveedor.id_proveedor);
                cmd.Parameters.AddWithValue("@razon_social", proveedor.razon_social);
                cmd.Parameters.AddWithValue("@ruc", proveedor.ruc);
                cmd.Parameters.AddWithValue("@direccion", proveedor.direccion);
                cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                cmd.Parameters.AddWithValue("@activo", proveedor.activo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public entProveedores BuscarProveedor(int idProveedor)
        {
            entProveedores prov = null;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    prov = new entProveedores
                    {
                        id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
                        razon_social = dr["razon_social"].ToString(),
                        ruc = dr["ruc"].ToString(),
                        direccion = dr["direccion"].ToString(),
                        contacto = dr["contacto"].ToString(),
                        activo = Convert.ToBoolean(dr["activo"])
                    };
                }
            }
            return prov;
        }

        public bool EliminarProveedor(int idProveedor)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }









    }
}
