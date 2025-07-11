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

    // Editar
    public bool EditarProducto(entProductos producto)
    {
        return datProducto.Instancia.EditarProducto(producto);
    }

    // Buscar
    public entProductos BuscarProducto(int idProducto)
    {
        return datProducto.Instancia.BuscarProducto(idProducto);
    }

    // Eliminar
    public bool EliminarProducto(int idProducto)
    {
        return datProducto.Instancia.EliminarProducto(idProducto);
    }

    public int ObtenerStockMinimo(int idProducto)
    {
        return datProducto.Instancia.ObtenerStockMinimo(idProducto);
    }





}
