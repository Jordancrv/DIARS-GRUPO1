using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapaEntidad;
using CapaLogica;
using System.Linq;
using System.Collections.Generic;

namespace SantaEulalia.Controllers
{
    public class ProductoController : Controller
    {
        // ========================
        // 👉 VISTA PARA CLIENTES (Tienda)
        // ========================
        [HttpGet]
        public IActionResult Tienda(string busqueda, int? categoriaId)
        {
            var productos = logProducto.Instancia.ListarProducto();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                productos = productos
                    .Where(p => p.nombre.Contains(busqueda, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (categoriaId.HasValue)
            {
                productos = productos
                    .Where(p => p.idCategoria == categoriaId.Value)
                    .ToList();
            }

            var listaCategorias = logCategoria.Instancia.ListarCategorias()
                .Select(c => new SelectListItem
                {
                    Value = c.idCategoria.ToString(),
                    Text = c.nombreCategoria
                })
                .ToList();

            ViewBag.Categorias = listaCategorias;
            ViewBag.Busqueda = busqueda;
            ViewBag.CategoriaSeleccionada = categoriaId;

            return View("Tienda", productos);
        }

        // ========================
        // 👉 VISTA PARA ADMINISTRADOR (Listar Productos)
        // ========================
        [HttpGet]
        public IActionResult Listar()
        {
            var productos = logProducto.Instancia.ListarProducto();
            return View(productos); // ← Asegúrate de tener la vista Views/Producto/Listar.cshtml
        }
    }
}
