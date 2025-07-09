using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class datComprobantePago
    {
        private static readonly datComprobantePago _instancia = new datComprobantePago();
        public static datComprobantePago Instancia => _instancia;

        public entComprobantePago ObtenerPorId(int id)
        {
            entComprobantePago comprobante = null;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ComprobantesPago WHERE id_comprobante = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        comprobante = new entComprobantePago
                        {
                            id_comprobante = Convert.ToInt32(dr["id_comprobante"]),
                            tipo = dr["tipo"].ToString(),
                            serie = dr["serie"].ToString(),
                            numero = dr["numero"].ToString(),
                            activo = Convert.ToBoolean(dr["activo"])
                        };
                    }
                }
            }
            return comprobante;
        }

        public List<entComprobantePago> ListarComprobantesPago()
        {
            List<entComprobantePago> lista = new List<entComprobantePago>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ComprobantesPago", cn))
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var comprobante = new entComprobantePago
                        {
                            id_comprobante = Convert.ToInt32(dr["id_comprobante"]),
                            tipo = dr["tipo"].ToString(),
                            serie = dr["serie"].ToString(),
                            numero = dr["numero"].ToString(),
                            activo = Convert.ToBoolean(dr["activo"])
                        };

                        lista.Add(comprobante);
                    }
                }
            }

            return lista;
        }



    }
}
