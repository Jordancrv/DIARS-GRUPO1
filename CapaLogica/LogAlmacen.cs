using System.Collections.Generic;
using CapaEntidad;

public class LogAlmacen
{
    private static readonly LogAlmacen _instancia = new LogAlmacen();
    public static LogAlmacen Instancia => _instancia;

    public List<Almacen> ListarAlmacenes()
    {
        return new List<Almacen>();
    }

    public bool RegistrarAlmacen(Almacen obj, out string mensaje)
    {
        mensaje = "Almacen registrado";
        return true;
    }
}
