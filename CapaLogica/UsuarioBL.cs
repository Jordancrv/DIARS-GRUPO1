using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class UsuarioBL
    {
        private static UsuarioBL instancia = null;
        public static UsuarioBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new UsuarioBL();
                return instancia;
            }
        }

        public entUsuario Login(string email, string password)
        {
            // Aquí llamas al DAO para validar
            return datUsuario.Instancia.Login(email, password);
        }
    }

}
