using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logClientes
    {

        #region Singleton
        private static readonly logClientes UnicaInstancia = new logClientes();

        public static logClientes Instancia
        {
            get
            {
                return logClientes.UnicaInstancia;
            }
        }
        #endregion

        public List<entClientes> ListarCliente()
        {
            return datCliente.Instancia.ListarCliente();
        }

        public bool InsertarCliente(entClientes cliente)
        {
            return datCliente.Instancia.InsertarCliente(cliente);
        }

        public bool EditarCliente(entClientes cliente)
        {
            return datCliente.Instancia.EditarCliente(cliente);
        }

        public entClientes BuscarCliente(int idCliente)
        {
            return datCliente.Instancia.BuscarCliente(idCliente);
        }

        public bool EliminarCliente(int idCliente)
        {
            return datCliente.Instancia.EliminarCliente(idCliente);
        }





    }
}
