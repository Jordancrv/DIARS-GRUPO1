using System.Collections.Generic;
using CapaEntidad;

public class LogProducto
{
    private static readonly LogProducto _instancia = new LogProducto();
    public static LogProducto Instancia => _instancia;

    public List<Producto> ListarProductos()
    {
        return new List<Producto>();
    }

    public bool RegistrarProducto(Producto obj, out string mensaje)
    {
        mensaje = "Producto registrado";
        return true;
    }

    public bool EditarProducto(Producto obj, out string mensaje)
    {
        mensaje = "Producto editado";
        return true;
    }

    public bool EliminarProducto(int id, out string mensaje)
    {
        mensaje = "Producto eliminado";
        return true;
    }
}
