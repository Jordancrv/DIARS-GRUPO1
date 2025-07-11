using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datPresentacion
    {
        private static readonly datPresentacion _instancia = new datPresentacion();
        public static datPresentacion Instancia => _instancia;

        public List<entPresentacion> Listar()
        {
            List<entPresentacion> lista = new List<entPresentacion>();
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT idPresentacion, nombrePresentacion FROM Presentacion", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entPresentacion
                    {
                        idPresentacion = (int)dr["idPresentacion"],
                        nombrePresentacion = dr["nombrePresentacion"].ToString()
                    });
                }
            }
            return lista;
        }
    }

}
