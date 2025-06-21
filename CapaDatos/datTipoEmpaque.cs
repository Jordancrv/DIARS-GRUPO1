using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datTipoEmpaque
    {
        private static readonly datTipoEmpaque _instancia = new datTipoEmpaque();
        public static datTipoEmpaque Instancia => _instancia;

        public List<entTipoEmpaque> Listar()
        {
            List<entTipoEmpaque> lista = new List<entTipoEmpaque>();
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT idTipoEmpaque, nombreEmpaque, material FROM TipoEmpaque", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entTipoEmpaque
                    {
                        idTipoEmpaque = (int)dr["idTipoEmpaque"],
                        nombreEmpaque = dr["nombreEmpaque"].ToString(),
                        material = dr["material"].ToString()
                    });
                }
            }
            return lista;
        }
    }

}
