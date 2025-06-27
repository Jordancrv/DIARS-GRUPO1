using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class logPromociones
    {

        #region Singleton
        private static readonly logPromociones UnicaInstancia = new logPromociones();

        public static logPromociones Instancia
        {
            get
            {
                return logPromociones.UnicaInstancia;
            }
        }
        #endregion

        // Listar
        public List<entPromociones> ListarPromociones()
        {
            return datPromociones.Instancia.ListarPromociones(); 
        }

        // Insertar
        public bool InsertarPromocion(entPromociones promocion)
        {
            return datPromociones.Instancia.InsertarPromocion(promocion);
        }

        //// Editar
        //public bool EditarPromocion(entPromociones promocion)
        //{
        //    return datPromociones.Instancia.EditarPromocion(promocion);
        //}

        //// Buscar por ID
        //public entPromociones BuscarPromocion(int idPromocion)
        //{
        //    return datPromociones.Instancia.BuscarPromocion(idPromocion);
        //}

        //// Eliminar
        //public bool EliminarPromocion(int idPromocion)
        //{
        //    return datPromociones.Instancia.EliminarPromocion(idPromocion);
        //}




    }
}
