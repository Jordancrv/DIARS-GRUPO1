using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProductos
    {
        public int id_producto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int stock_minimo { get; set; }
        public string unidad_medida { get; set; }
        public int id_proveedor { get; set; }
        public int idCategoria { get; set; }
        public int idPresentacion { get; set; } 
        public int idTipoEmpaque { get; set; }

        public bool activo { get; set; }

        // Relaciones
        

        // Propiedades de navegación (opcional si usas ViewModel)
        public string nombreProveedor { get; set; }
        public string nombreCategoria { get; set; }
        public string nombrePresentacion { get; set; }
        public string nombreTipoEmpaque { get; set; }

    }
    public class entProveedores
    {
        public int id_proveedor { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public bool activo { get; set; }

        public List<string> telefonos { get; set; }
        public List<string> correos { get; set; }

        public List<entProductos> Productos { get; set; }

        public entProveedores()
        {
            telefonos = new List<string>();
            correos = new List<string>();
            Productos = new List<entProductos>();
        }
    }







}
