using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

public class logUsuario
{
    private static readonly logUsuario _instancia = new logUsuario();
    public static logUsuario Instancia => _instancia;

    public bool Registrar(entUsuario usuario)
    {
        return datUsuario.Instancia.InsertarUsuario(usuario);
    }

    public List<entUsuario> Listar()
    {
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
    }
}