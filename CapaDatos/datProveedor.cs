using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class datProveedor
    {
        #region Singleton
        private static readonly datProveedor _instancia = new datProveedor();
        public static datProveedor Instancia => _instancia;
        #endregion

        public List<entProveedores> ListarProveedores()
        {
            List<entProveedores> lista = new List<entProveedores>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProveedoresCompleto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id_proveedor"]);
                    var prov = lista.FirstOrDefault(p => p.id_proveedor == id);

                    if (prov == null)
                    {
                        prov = new entProveedores
                        {
                            id_proveedor = id,
                            razon_social = dr["razon_social"].ToString(),
                            ruc = dr["ruc"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            contacto = dr["contacto"].ToString(),
                            activo = Convert.ToBoolean(dr["activo"]),
                            telefonos = new List<string>(),
                            correos = new List<string>(),
                            Productos = new List<entProductos>()
                        };
                        lista.Add(prov);
                    }

                    if (dr["telefono"] != DBNull.Value)
                    {
                        string tel = dr["telefono"].ToString();
                        if (!prov.telefonos.Contains(tel))
                            prov.telefonos.Add(tel);
                    }

                    if (dr["email"] != DBNull.Value)
                    {
                        string mail = dr["email"].ToString();
                        if (!prov.correos.Contains(mail))
                            prov.correos.Add(mail);
                    }
                }
            }
            return lista;
        }

        public bool InsertarProveedor(entProveedores proveedor)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProveedorCompleto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@razon_social", proveedor.razon_social);
                cmd.Parameters.AddWithValue("@ruc", proveedor.ruc);
                cmd.Parameters.AddWithValue("@direccion", proveedor.direccion);
                cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                cmd.Parameters.AddWithValue("@activo", true);


                // Correos como DataTable
                DataTable correosTable = new DataTable();
                correosTable.Columns.Add("email", typeof(string));
                foreach (string correo in proveedor.correos)
                {
                    correosTable.Rows.Add(correo);
                }

                // Teléfonos como DataTable
                DataTable telefonosTable = new DataTable();
                telefonosTable.Columns.Add("telefono", typeof(string));
                foreach (string tel in proveedor.telefonos)
                {
                    telefonosTable.Rows.Add(tel);
                }

                SqlParameter pCorreos = cmd.Parameters.AddWithValue("@Correos", correosTable);
                pCorreos.SqlDbType = SqlDbType.Structured;
                pCorreos.TypeName = "dbo.CorreoTableType";

                SqlParameter pTelefonos = cmd.Parameters.AddWithValue("@Telefonos", telefonosTable);
                pTelefonos.SqlDbType = SqlDbType.Structured;
                pTelefonos.TypeName = "dbo.TelefonoTableType";

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
                cmd.Parameters.AddWithValue("@activo", true);

                // Correos
                DataTable correosTable = new DataTable();
                correosTable.Columns.Add("email", typeof(string));
                foreach (string correo in proveedor.correos)
                {
                    correosTable.Rows.Add(correo);
                }

                SqlParameter pCorreos = cmd.Parameters.AddWithValue("@Correos", correosTable);
                pCorreos.SqlDbType = SqlDbType.Structured;
                pCorreos.TypeName = "dbo.CorreoTableType";

                // Teléfonos
                DataTable telefonosTable = new DataTable();
                telefonosTable.Columns.Add("telefono", typeof(string));
                foreach (string tel in proveedor.telefonos)
                {
                    telefonosTable.Rows.Add(tel);
                }

                SqlParameter pTelefonos = cmd.Parameters.AddWithValue("@Telefonos", telefonosTable);
                pTelefonos.SqlDbType = SqlDbType.Structured;
                pTelefonos.TypeName = "dbo.TelefonoTableType";

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }



        //public entProveedores BuscarProveedor(int idProveedor)
        //{
        //    entProveedores prov = null;
        //    using (SqlConnection cn = Conexion.Instancia.Conectar())
        //    {
        //        cn.Open();

        //        // Datos principales del proveedor
        //        SqlCommand cmd = new SqlCommand("sp_BuscarProveedor", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            if (dr.Read())
        //            {
        //                prov = new entProveedores
        //                {
        //                    id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
        //                    razon_social = dr["razon_social"].ToString(),
        //                    ruc = dr["ruc"].ToString(),
        //                    direccion = dr["direccion"].ToString(),
        //                    contacto = dr["contacto"].ToString(),
        //                    activo = Convert.ToBoolean(dr["activo"]),
        //                    telefonos = new List<string>(),
        //                    correos = new List<string>()
        //                };
        //            }
        //        }

        //        if (prov != null)
        //        {
        //            // Correos
        //            SqlCommand cmdCorreos = new SqlCommand("sp_ListarCorreosProveedor", cn);
        //            cmdCorreos.CommandType = CommandType.StoredProcedure;
        //            cmdCorreos.Parameters.AddWithValue("@id_proveedor", idProveedor);
        //            using (SqlDataReader dr = cmdCorreos.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    prov.correos.Add(dr["email"].ToString());
        //                }
        //            }

        //            // Teléfonos
        //            SqlCommand cmdTelefonos = new SqlCommand("sp_ListarTelefonosProveedor", cn);
        //            cmdTelefonos.CommandType = CommandType.StoredProcedure;
        //            cmdTelefonos.Parameters.AddWithValue("@id_proveedor", idProveedor);
        //            using (SqlDataReader dr = cmdTelefonos.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    prov.telefonos.Add(dr["telefono"].ToString());
        //                }
        //            }
        //        }
        //    }

        //    return prov;
        //}





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
                        activo = Convert.ToBoolean(dr["activo"]),
                        telefonos = new List<string>(),
                        correos = new List<string>()
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
        public decimal ObtenerPrecioProveedor(int idProveedor, int idProducto)
        {
            decimal precio = 0;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPrecioProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    precio = Convert.ToDecimal(result);
            }
            return precio;
        }

    }
}
