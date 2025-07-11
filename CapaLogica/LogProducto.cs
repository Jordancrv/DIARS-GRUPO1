using System.Collections.Generic;
using CapaEntidad;
using CapaDatos; 

public class logProducto
{
    #region Singleton
    private static readonly logProducto UnicaInstancia = new logProducto();

    public static logProducto Instancia
    {
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
    }

    // Insertar
    public bool InsertarProducto(entProductos producto)
    {
        return datProducto.Instancia.InsertarProducto(producto);
    }
    public entProductos BuscarProductoPorId(int id)
    {
        return datProducto.Instancia.BuscarProductoPorId(id);
    }
    // Editar
    public bool EditarProducto(entProductos producto)
    {
        return datProducto.Instancia.EditarProducto(producto);
    }


    // Eliminar
    public bool EliminarProducto(int id)
    {
        return datProducto.Instancia.EliminarProducto(id);
    }

    public int ObtenerStockMinimo(int idProducto)
    {
        return datProducto.Instancia.ObtenerStockMinimo(idProducto);
    }





}
