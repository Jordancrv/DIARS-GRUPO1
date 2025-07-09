using System.Collections.Generic;
using CapaEntidad;

public class LogProducto
{
    private static readonly LogProducto _instancia = new LogProducto();
    public static LogProducto Instancia => _instancia;

    public List<entProductos> ListarProductos()
    {
<<<<<<< Updated upstream
        return new List<entProductos>();
=======
        get
        {
            return logProducto.UnicaInstancia;
        }
    }
    #endregion

    // Listar


    public List<entProductos> ListarProducto()
    {
        return datProducto.Instancia.ListarProductos();
>>>>>>> Stashed changes
    }

    public bool RegistrarProducto(entProductos obj, out string mensaje)
    {
        mensaje = "Producto registrado";
        return true;
    }

    public bool EditarProducto(entProductos obj, out string mensaje)
    {
        mensaje = "Producto editado";
        return true;
    }

    public bool EliminarProducto(int id, out string mensaje)
    {
        mensaje = "Producto eliminado";
        return true;
    }
<<<<<<< Updated upstream
=======

    // Eliminar
    public bool EliminarProducto(int idProducto)
    {
        return datProducto.Instancia.EliminarProducto(idProducto);
    }

    public int ObtenerStockMinimo(int idProducto)
    {
        return datProducto.Instancia.ObtenerStockMinimo(idProducto);
    }





>>>>>>> Stashed changes
}
