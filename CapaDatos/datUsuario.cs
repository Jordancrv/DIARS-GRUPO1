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
  
        public class datUsuario
        {
            private static readonly datUsuario _instancia = new datUsuario();
            public static datUsuario Instancia => _instancia;

            public bool InsertarUsuario(entUsuario usuario)
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("@apellidos", usuario.apellidos);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@password_hash", usuario.password_hash);
                    cmd.Parameters.AddWithValue("@rol", usuario.rol);
                    cmd.Parameters.AddWithValue("@activo", usuario.activo);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            public List<entUsuario> ListarUsuarios()
            {
                List<entUsuario> lista = new List<entUsuario>();

                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new entUsuario
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre = dr["nombre"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                email = dr["email"].ToString(),
                                password_hash = dr["password_hash"].ToString(),
                                rol = dr["rol"].ToString(),
                                fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
                                activo = Convert.ToBoolean(dr["activo"])
                            });
                        }
                    }
                }

                return lista;
            }

            public entUsuario BuscarUsuarioPorId(int id)
            {
                entUsuario usuario = null;

                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarUsuarioPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", id);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new entUsuario
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre = dr["nombre"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                email = dr["email"].ToString(),
                                password_hash = dr["password_hash"].ToString(),
                                rol = dr["rol"].ToString(),
                                fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
                                activo = Convert.ToBoolean(dr["activo"])
                            };
                        }
                    }
                }

                return usuario;
            }

            public bool ActualizarUsuario(entUsuario usuario)
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
                    cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("@apellidos", usuario.apellidos);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@password_hash", usuario.password_hash);
                    cmd.Parameters.AddWithValue("@rol", usuario.rol);
                    cmd.Parameters.AddWithValue("@activo", usuario.activo);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            public bool EliminarUsuario(int idUsuario)
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }




    
}
