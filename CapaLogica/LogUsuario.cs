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
<<<<<<< Updated upstream
        return new List<entUsuario>();
=======
        return datUsuario.Instancia.ListarUsuarios();
    }

    public entUsuario BuscarPorId(int id)
    {
        return datUsuario.Instancia.BuscarUsuarioPorId(id);
    }

    public bool Editar(entUsuario usuario)
    {
        return datUsuario.Instancia.ActualizarUsuario(usuario);
    }

    public bool Eliminar(int id)
    {
        return datUsuario.Instancia.EliminarUsuario(id);
>>>>>>> Stashed changes
    }
}