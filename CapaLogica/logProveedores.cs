using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class logProveedores
    {

        private static readonly logProveedores _instancia = new logProveedores();

        public static logProveedores Instancia
        {
            get { return _instancia; }
        }

        public List<entProveedores> ListarProveedores()
        {
            return datProveedor.Instancia.ListarProveedores();
        }

        public bool InsertarProveedor(entProveedores proveedor)
        {
            return datProveedor.Instancia.InsertarProveedor(proveedor);
        }


        public bool EditarProveedor(entProveedores proveedor)
        {
            return datProveedor.Instancia.EditarProveedor(proveedor);
        }

        public entProveedores BuscarProveedor(int idProveedor)
        {
            return datProveedor.Instancia.BuscarProveedor(idProveedor);
        }

        public bool EliminarProveedor(int idProveedor)
        {
            return datProveedor.Instancia.EliminarProveedor(idProveedor);
        }



    }
}
