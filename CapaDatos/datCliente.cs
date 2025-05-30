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
    public class datCliente
    {

        #region Singleton
        private static readonly datCliente _instancia = new datCliente();

        public static datCliente Instancia
        {
            get { return _instancia; }
        }
        #endregion

        public List<entClientes> ListarCliente()
        {
            List<entClientes> lista = new List<entClientes>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entClientes cli = new entClientes
                    {
                        id_cliente = Convert.ToInt32(dr["id_cliente"]),
                        razon_social = dr["razon_social"].ToString(),
                        ruc = dr["ruc"].ToString(),
                        direccion = dr["direccion"].ToString(),
                        telefono = dr["telefono"].ToString(),
                        email = dr["email"].ToString(),
                        activo = Convert.ToBoolean(dr["activo"])
                    };
                    lista.Add(cli);
                }
            }
            return lista;
        }

        public bool InsertarCliente(entClientes cliente)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razon_social", cliente.razon_social);
                cmd.Parameters.AddWithValue("@ruc", cliente.ruc);
                cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@activo", cliente.activo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EditarCliente(entClientes cliente)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                cmd.Parameters.AddWithValue("@razon_social", cliente.razon_social);
                cmd.Parameters.AddWithValue("@ruc", cliente.ruc);
                cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@activo", cliente.activo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public entClientes BuscarCliente(int idCliente)
        {
            entClientes cli = null;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cli = new entClientes
                    {
                        id_cliente = Convert.ToInt32(dr["id_cliente"]),
                        razon_social = dr["razon_social"].ToString(),
                        ruc = dr["ruc"].ToString(),
                        direccion = dr["direccion"].ToString(),
                        telefono = dr["telefono"].ToString(),
                        email = dr["email"].ToString(),
                        activo = Convert.ToBoolean(dr["activo"])
                    };
                }
            }
            return cli;
        }

        public bool EliminarCliente(int idCliente)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminaEditaCliente(int idCliente)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminaEditaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }








    }
}
