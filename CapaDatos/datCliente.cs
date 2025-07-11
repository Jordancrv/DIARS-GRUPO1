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

        public List<entClientes> ListarClientes()
        {
            List<entClientes> lista = new List<entClientes>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarClienteCompleto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id_cliente"]);

                    // Busca si ya está agregado
                    var cliente = lista.FirstOrDefault(c => c.id_cliente == id);

                    if (cliente == null)
                    {
                        cliente = new entClientes
                        {
                            id_cliente = id,
                            id_tipo_cliente = Convert.ToInt32(dr["id_tipo_cliente"]),
                            nombres = dr["nombres"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            dni = dr["dni"].ToString(),
                            razon_social = dr["razon_social"].ToString(),
                            ruc = dr["ruc"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            idUsuario = dr["id_usuario"] != DBNull.Value ? dr["id_usuario"].ToString() : null,
                            activo = Convert.ToBoolean(dr["activo"]),
                            telefonos = new List<string>(),
                            correos = new List<string>()
                        };
                        lista.Add(cliente);
                    }

                    // Agrega teléfono si existe
                    if (dr["telefono"] != DBNull.Value)
                    {
                        string tel = dr["telefono"].ToString();
                        if (!cliente.telefonos.Contains(tel))
                            cliente.telefonos.Add(tel);
                    }

                    // Agrega correo si existe
                    if (dr["email"] != DBNull.Value)
                    {
                        string mail = dr["email"].ToString();
                        if (!cliente.correos.Contains(mail))
                            cliente.correos.Add(mail);
                    }
                }
            }

            return lista;
        }

        public bool InsertarComprobante(string tipoComprobante, out string serieGenerada, out string numeroGenerado)
        {
            serieGenerada = string.Empty;
            numeroGenerado = string.Empty;

            // Utilizamos el método Conectar() de tu clase Conexion
            using (SqlConnection connection = Conexion.Instancia.Conectar())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertarComprobantePago", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada para el tipo de comprobante
                        command.Parameters.AddWithValue("@tipo", tipoComprobante);

                        // Parámetros de salida para la serie y el número generados
                        SqlParameter serieOutParam = new SqlParameter("@serie_out", SqlDbType.VarChar, 20);
                        serieOutParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(serieOutParam);

                        SqlParameter numeroOutParam = new SqlParameter("@numero_out", SqlDbType.VarChar, 20);
                        numeroOutParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(numeroOutParam);

                        connection.Open(); // Abre la conexión obtenida de tu clase Conexion
                        command.ExecuteNonQuery();

                        // Obtener los valores de los parámetros de salida
                        serieGenerada = serieOutParam.Value.ToString();
                        numeroGenerado = numeroOutParam.Value.ToString();

                        Console.WriteLine($"Comprobante '{tipoComprobante}' insertado exitosamente.");
                        Console.WriteLine($"Serie generada: {serieGenerada}");
                        Console.WriteLine($"Número generado: {numeroGenerado}");
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    // Manejo de errores específicos de SQL (ej. tipo de comprobante no válido)
                    Console.WriteLine($"Error de SQL al insertar comprobante: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    // Manejo de otros errores
                    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    return false;
                }
                finally
                {
                    // El 'using' statement para SqlConnection se encarga de cerrar la conexión
                    // automáticamente cuando sale del bloque, incluso si hay una excepción.
                    // No es necesario llamar a connection.Close() explícitamente aquí.
                }
            }
        }


        public int InsertarClienteYDetalle(entClientes cliente)
        {
            int idGenerado = 0;

            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                con.Open();

                try
                {
                    // Insertar cliente principal y obtener ID generado
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarCliente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_tipo_cliente", cliente.id_tipo_cliente);
                        cmd.Parameters.AddWithValue("@nombres", cliente.nombres ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@apellidos", cliente.apellidos ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dni", cliente.dni ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@razon_social", cliente.razon_social ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ruc", cliente.ruc ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@direccion", cliente.direccion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_usuario", cliente.idUsuario ?? (object)DBNull.Value); // Nuevo parámetro para el usuario que crea el cliente   
                        cmd.Parameters.AddWithValue("@activo", cliente.activo);

                        object result = cmd.ExecuteScalar();
                        idGenerado = Convert.ToInt32(result);
                    }

                    // Insertar correos
                    foreach (var correo in cliente.correos)
                    {
                        using (SqlCommand cmdCorreo = new SqlCommand("sp_InsertarClienteCorreo", con))
                        {
                            cmdCorreo.CommandType = CommandType.StoredProcedure;
                            cmdCorreo.Parameters.AddWithValue("@id_cliente", idGenerado);
                            cmdCorreo.Parameters.AddWithValue("@correo", correo);
                            cmdCorreo.ExecuteNonQuery();
                        }
                    }

                    // Insertar teléfonos
                    foreach (var tel in cliente.telefonos)
                    {
                        using (SqlCommand cmdTel = new SqlCommand("sp_InsertarClienteTelefono", con))
                        {
                            cmdTel.CommandType = CommandType.StoredProcedure;
                            cmdTel.Parameters.AddWithValue("@id_cliente", idGenerado);
                            cmdTel.Parameters.AddWithValue("@telefono", tel);
                            cmdTel.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                    throw; // Se puede agregar logging si deseas registrar el error.
                }
            }

            return idGenerado;
        }



        public bool EditarCliente(entClientes cliente)
        {
            bool result = false;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarCliente", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                cmd.Parameters.AddWithValue("@id_tipo_cliente", cliente.id_tipo_cliente);
                cmd.Parameters.AddWithValue("@nombres", (object)cliente.nombres ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@apellidos", (object)cliente.apellidos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dni", (object)cliente.dni ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@razon_social", (object)cliente.razon_social ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ruc", (object)cliente.ruc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)cliente.direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id_usuario", (object)cliente.idUsuario ?? DBNull.Value); // Nuevo parámetro para el usuario que edita el cliente
                cmd.Parameters.AddWithValue("@activo", cliente.activo);
                cn.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmdDelCorreo = new SqlCommand("DELETE FROM ClienteCorreos WHERE id_cliente = @id_cliente", cn);
                cmdDelCorreo.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                cmdDelCorreo.ExecuteNonQuery();

                // Insertar nuevos correos
                foreach (var email in cliente.correos)
                {
                    SqlCommand cmdCorreo = new SqlCommand("sp_InsertarClienteCorreo", cn);
                    cmdCorreo.CommandType = CommandType.StoredProcedure;
                    cmdCorreo.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                    cmdCorreo.Parameters.AddWithValue("@correo", email);
                    cmdCorreo.ExecuteNonQuery();
                    cmdCorreo.Dispose();
                }

                // Borrar teléfonos antiguos
                SqlCommand cmdDelTelefono = new SqlCommand("DELETE FROM ClienteTelefonos WHERE id_cliente = @id_cliente", cn);
                cmdDelTelefono.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                cmdDelTelefono.ExecuteNonQuery();

                // Insertar nuevos teléfonos
                foreach (var telefono in cliente.telefonos)
                {
                    SqlCommand cmdTel = new SqlCommand("sp_InsertarClienteTelefono", cn);
                    cmdTel.CommandType = CommandType.StoredProcedure;
                    cmdTel.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                    cmdTel.Parameters.AddWithValue("@telefono", telefono);
                    cmdTel.ExecuteNonQuery();
                    cmdTel.Dispose();
                }


                // Actualizar correos y teléfonos según la lógica del sistema (por ejemplo: eliminar y volver a insertar)
                result = true;
            }
            return result;
        }

        public entClientes BuscarCliente(int idCliente)
        {
            try
            {
                entClientes cli = null;
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarCliente", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cli = new entClientes
                        {
                            id_cliente = Convert.ToInt32(dr["id_cliente"]),
                            id_tipo_cliente = Convert.ToInt32(dr["id_tipo_cliente"]),
                            nombres = dr["nombres"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            dni = dr["dni"].ToString(),
                            razon_social = dr["razon_social"].ToString(),
                            ruc = dr["ruc"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            idUsuario = dr["id_usuario"] != DBNull.Value ? dr["id_usuario"].ToString() : null, // Nuevo campo para el usuario que creó el cliente
                            activo = Convert.ToBoolean(dr["activo"]),
                            telefonos = new List<string>(),
                            correos = new List<string>()
                        };
                    }

                    SqlCommand cmdCorreo = new SqlCommand("SELECT email FROM ClienteCorreos WHERE id_cliente = @id", cn);
                    cmdCorreo.Parameters.AddWithValue("@id", idCliente);
                    SqlDataReader drCorreo = cmdCorreo.ExecuteReader();
                    while (drCorreo.Read())
                        cli.correos.Add(drCorreo["email"].ToString());
                    drCorreo.Close();

                    // Leer teléfonos
                    SqlCommand cmdTel = new SqlCommand("SELECT telefono FROM ClienteTelefonos WHERE id_cliente = @id", cn);
                    cmdTel.Parameters.AddWithValue("@id", idCliente);
                    SqlDataReader drTel = cmdTel.ExecuteReader();
                    while (drTel.Read())
                        cli.telefonos.Add(drTel["telefono"].ToString());
                    drTel.Close();

                }
                return cli;
            }
            catch (SqlException e)
            {

                throw new ApplicationException("Error al ingresar los datos, por favor ingrese los datos correctamente");

            }
        }

        public bool EliminarCliente(int idCliente)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //public bool DesactivarCliente(int idCliente)
        //{
        //    using (SqlConnection cn = Conexion.Instancia.Conectar())
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_DesactivarCliente", cn)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
        //        cn.Open();
        //        return cmd.ExecuteNonQuery() > 0;
        //    }
        //}


    }
}
