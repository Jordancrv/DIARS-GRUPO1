using CapaEntidad;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class datMetodoPago
    {
        private static readonly datMetodoPago _instancia = new datMetodoPago();
        public static datMetodoPago Instancia => _instancia;

        public List<MetodoPago> Listar()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_metodo_pago, nombre, descripcion, activo FROM MetodosPago WHERE activo = 1", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new MetodoPago
                    {
                        id_metodo_pago = (int)dr["id_metodo_pago"],
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        activo = (bool)dr["activo"]
                    });
                }
            }
            return lista;
        }
    }
}
