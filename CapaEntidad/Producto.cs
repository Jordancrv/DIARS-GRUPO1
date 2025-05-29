using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        public int LineaProductoId { get; set; }
        public LineaProducto LineaProducto { get; set; }

        public bool Estado { get; set; } = true;
        public List<entPresentacion> Presentaciones { get; set; }

        public string DescripcionCompleta => $"{Codigo} - {Nombre} ({Marca?.Nombre})";
    }

    public class Permiso
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; } 

        public List<RolPermiso> Roles { get; set; }

        public override string ToString() => $"{Nombre} ({Codigo})";
    }
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Permiso> Permisos { get; set; }
    }
    public class RolPermiso
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int PermisoId { get; set; }
        public Permiso Permiso { get; set; }
    }
    

}
