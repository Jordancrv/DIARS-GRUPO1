using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class datCategoria
    {
        private static readonly datCategoria _instancia = new datCategoria();
        public static datCategoria Instancia => _instancia;

        public List<entCategoria> Listar()
        {
            var lista = new List<entCategoria>();
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT idCategoria, nombreCategoria FROM CategoriaProductos", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entCategoria
                    {
                        idCategoria = (int)dr["idCategoria"],
                        nombreCategoria = dr["nombreCategoria"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
