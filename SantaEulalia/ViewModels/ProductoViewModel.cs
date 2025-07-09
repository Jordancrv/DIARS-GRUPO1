using CapaEntidad;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SantaEulalia.ViewModels
{
    public class ProductoViewModel
    {
        public entProductos Producto { get; set; }

        public List<SelectListItem> Proveedores { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Presentaciones { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposEmpaque { get; set; } = new List<SelectListItem>();
    }
}
