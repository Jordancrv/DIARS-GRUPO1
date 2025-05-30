using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datProducto
    {
        #region Singleton
        private static readonly datProducto UnicaInstancia = new datProducto();
        public static datProducto Instancia
        {
            get { return datProducto.UnicaInstancia; }
        }
        #endregion Singleton
    }
}
