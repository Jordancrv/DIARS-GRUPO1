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
    public class datPromociones
    {


        #region Singleton
        private static readonly datPromociones _instancia = new datPromociones();

        #endregion


        public static datPromociones Instancia
        {
            get
            {
                return _instancia;
            }
        }

        public List<entPromociones> ListarPromociones()
        {
            List<entPromociones> lista = new List<entPromociones>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPromociones", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entPromociones
                    {
                        IdPromocion = Convert.ToInt32(dr["IdPromocion"]),
                        NombrePromocion = dr["NombrePromocion"].ToString(),
                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                        FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                        TipoPromocion = dr["TipoPromocion"].ToString(), // <-- Cambiado
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }
            return lista;
        }

        public bool InsertarPromocion(entPromociones promo)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarPromocion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombrePromocion", promo.NombrePromocion);
                cmd.Parameters.AddWithValue("@Descuento", promo.Descuento);
                cmd.Parameters.AddWithValue("@FechaInicio", promo.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", promo.FechaFin);
                cmd.Parameters.AddWithValue("@id_tipo_promocion", promo.idTipoPromocion);
                cmd.Parameters.AddWithValue("@Estado", promo.Estado);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // NUEVO MÉTODO: BuscarPromocionActivaPorProducto
        public entPromociones BuscarPromocionActivaPorProducto(int idProducto)
        {
            entPromociones objPromocion = null;
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarPromocionActivaPorProductoSimple", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            objPromocion = new entPromociones()
                            {
                                IdPromocion = Convert.ToInt32(dr["IdPromocion"]),
                                NombrePromocion = dr["NombrePromocion"].ToString(),
                                Descuento = Convert.ToDecimal(dr["Descuento"]),
                                TipoPromocion = dr["TipoPromocion"].ToString()
                                // FechaInicio y FechaFin no son estrictamente necesarias aquí si solo buscas aplicarla
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: loguear el error para depuración
                Console.WriteLine("Error en datPromociones.BuscarPromocionActivaPorProducto: " + ex.Message);
                objPromocion = null;
            }
            return objPromocion;
        }
        public List<PromocionProductoDTO> ListarPromocionesActivasPorProducto()
        {
            List<PromocionProductoDTO> lista = new List<PromocionProductoDTO>();
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    // Usamos el procedimiento almacenado que definiremos a continuación
                    SqlCommand cmd = new SqlCommand("sp_ListarPromocionesActivasPorProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new PromocionProductoDTO()
                            {
                                IdPromocion = Convert.ToInt32(dr["IdPromocion"]),
                                NombrePromocion = dr["NombrePromocion"].ToString(),
                                Descuento = Convert.ToDecimal(dr["Descuento"]),
                                TipoPromocion = dr["TipoPromocion"].ToString(),
                                IdProducto = Convert.ToInt32(dr["id_producto"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en datPromociones.ListarPromocionesActivasPorProducto: " + ex.Message);
                throw ex; // Relanza la excepción para que sea manejada en la capa de negocio/controlador
            }
            return lista;
        }




        public bool InhabilitarPromocion(int idPromocion)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_InhabilitarPromocion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public List<entTipoPromocion> Listar()
        {
            List<entTipoPromocion> lista = new List<entTipoPromocion>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarTipoPromocion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entTipoPromocion
                    {
                        IdTipoPromocion = Convert.ToInt32(dr["id_tipo_promocion"]),
                        NombreTipo = dr["nombre_tipo"].ToString()
                    });
                }
            }
            return lista;
        }






    }
}
