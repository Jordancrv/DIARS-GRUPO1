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
            bool result = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                SqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    int idGenerado;

                    // 1. Insertar Usuario y obtener ID con ExecuteScalar
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", cn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombres", (object)usuario.nombres ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@apellidos", (object)usuario.apellidos ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@password_hash", (object)usuario.password_hash ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@rol", (object)usuario.rol ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@activo", usuario.activo);

                        // Ejecutamos y capturamos el ID generado
                        idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insertar Correos asociados
                    try
                    {
                        foreach (var correo in usuario.correos)
                        {
                            using (SqlCommand cmdCorreo = new SqlCommand("sp_InsertarCorreoUsuarios", cn, transaction))
                            {
                                cmdCorreo.CommandType = CommandType.StoredProcedure;
                                cmdCorreo.Parameters.AddWithValue("@id_usuario", idGenerado);
                                cmdCorreo.Parameters.AddWithValue("@correo", correo ?? string.Empty);
                                cmdCorreo.ExecuteNonQuery();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al insertar correos: " + ex.Message);
                    }
                    transaction.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al insertar el usuario: " + ex.Message);
                }
            }

            return result;
        }

      
        //private void InsertarCorreoUsuario(int idUsuario, string correo)
        //{
        //    using (SqlConnection con = Conexion.Instancia.Conectar())
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_InsertarCorreoUsuario", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
        //        cmd.Parameters.AddWithValue("@correo", correo);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}




        //public entUsuario Login(string email, string password)
        //{
        //    entUsuario usuario = null;
        //    string hashedPassword = Utilidades.HashPassword(password); // Asegúrate de tener esta función

        //    using (SqlConnection cn = Conexion.Instancia.Conectar())
        //    {
        //        SqlCommand cmd = new SqlCommand(@"
        //    SELECT * 
        //    FROM Usuarios 
        //    WHERE email = @email AND password_hash = @password AND activo = 1", cn);

        //        cmd.Parameters.AddWithValue("@email", email);
        //        cmd.Parameters.AddWithValue("@password", hashedPassword);

        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            usuario = new entUsuario
        //            {
        //                id_usuario = Convert.ToInt32(dr["id_usuario"]),
        //                nombre = dr["nombres"].ToString(),
        //                apellidos = dr["apellidos"].ToString(),
        //                email = dr["email"].ToString(),
        //                password_hash = dr["password_hash"].ToString(),
        //                rol = dr["rol"].ToString(),
        //                fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
        //                activo = Convert.ToBoolean(dr["activo"])
        //            };
        //        }
        //    }

        //    return usuario;
        //}

        public entUsuario Login(string email, string password)
        {
            entUsuario usuario = null;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT u.*, uc.email
            FROM Usuarios u
            INNER JOIN UsuarioCorreos uc ON u.id_usuario = uc.id_usuario
            WHERE uc.email = @correo AND u.password_hash = @password", cn);

                cmd.Parameters.AddWithValue("@correo", email);
                cmd.Parameters.AddWithValue("@password", password); // Idealmente, compara el hash

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new entUsuario
                    {
                        id_usuario = Convert.ToInt32(dr["id_usuario"]),
                        nombres = dr["nombres"].ToString(), // estaba mal antes
                        apellidos = dr["apellidos"].ToString(),
                        password_hash = dr["password_hash"].ToString(),
                        rol = dr["rol"].ToString(),
                        fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
                        activo = Convert.ToBoolean(dr["activo"])
                    };
                }
            }

            return usuario;
        }


        public List<entUsuario> ListarUsuarios()
        {
            Dictionary<int, entUsuario> usuariosDic = new Dictionary<int, entUsuario>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id_usuario = Convert.ToInt32(dr["id_usuario"]);

                        if (!usuariosDic.ContainsKey(id_usuario))
                        {
                            usuariosDic[id_usuario] = new entUsuario
                            {
                                id_usuario = id_usuario,
                                nombres = dr["nombres"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                password_hash = dr["password_hash"].ToString(),
                                rol = dr["rol"].ToString(),
                                fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
                                activo = Convert.ToBoolean(dr["activo"]),
                                correos = new List<string>()
                            };
                        }

                        string email = dr["email"].ToString();
                        if (!usuariosDic[id_usuario].correos.Contains(email))
                        {
                            usuariosDic[id_usuario].correos.Add(email);
                        }
                    }
                }
            }

            return usuariosDic.Values.ToList();
        }

        //public entUsuario BuscarUsuarioPorId(int id)
        //    {
        //        entUsuario usuario = null;

        //        using (SqlConnection cn = Conexion.Instancia.Conectar())
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BuscarUsuarioPorId", cn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@id_usuario", id);

        //            cn.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    usuario = new entUsuario
        //                    {
        //                        id_usuario = Convert.ToInt32(dr["id_usuario"]),
        //                        nombres = dr["nombres"].ToString(),
        //                        apellidos = dr["apellidos"].ToString(),
        //                        email = dr["email"].ToString(),
        //                        password_hash = dr["password_hash"].ToString(),
        //                        rol = dr["rol"].ToString(),
        //                        fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]),
        //                        activo = Convert.ToBoolean(dr["activo"])
        //                    };
        //                }
        //            }
        //        }

        //        return usuario;
        //    }

            //public bool ActualizarUsuario(entUsuario usuario)
            //{
            //    using (SqlConnection cn = Conexion.Instancia.Conectar())
            //    {
            //        SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", cn);
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
            //        cmd.Parameters.AddWithValue("@nombres", usuario.nombres);
            //        cmd.Parameters.AddWithValue("@apellidos", usuario.apellidos);
            //        cmd.Parameters.AddWithValue("@email", usuario.email);
            //        cmd.Parameters.AddWithValue("@password_hash", usuario.password_hash);
            //        cmd.Parameters.AddWithValue("@rol", usuario.rol);
            //        cmd.Parameters.AddWithValue("@activo", usuario.activo);

            //        cn.Open();
            //        return cmd.ExecuteNonQuery() > 0;
            //    }
            //}

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
