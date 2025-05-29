using System.Collections.Generic;
using CapaEntidad;

public class LogUsuario
{
    private static readonly LogUsuario _instancia = new LogUsuario();
    public static LogUsuario Instancia => _instancia;

    public entUsuario Login(string usuario, string clave)
    {
        return new entUsuario();
    }

    public List<entUsuario> ListarUsuarios()
    {
        return new List<entUsuario>();
    }
}