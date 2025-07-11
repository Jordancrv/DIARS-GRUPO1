using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SantaEulalia.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
        // 👉 PANEL ADMIN
        // ========================

        [HttpGet]
        public IActionResult Listar()
        {
            var productos = logProducto.Instancia.ListarProducto();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Detalles(int id)
        {
            var producto = logProducto.Instancia.BuscarProductoPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View(CargarViewModel(new ProductoViewModel()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ProductoViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(CargarViewModel(vm));

            bool exito = logProducto.Instancia.InsertarProducto(vm.Producto);
            if (exito)
                return RedirectToAction("Listar");

            ModelState.AddModelError("", "No se pudo registrar el producto.");
            return View(CargarViewModel(vm));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var producto = logProducto.Instancia.BuscarProductoPorId(id);
            if (producto == null)
                return NotFound();

            var vm = new ProductoViewModel { Producto = producto };
            return View(CargarViewModel(vm));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ProductoViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(CargarViewModel(vm));

            bool exito = logProducto.Instancia.EditarProducto(vm.Producto);
            if (exito)
                return RedirectToAction("Listar");

            ModelState.AddModelError("", "No se pudo editar el producto.");
            return View(CargarViewModel(vm));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var producto = logProducto.Instancia.BuscarProductoPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(entProductos producto)
        {
            bool exito = logProducto.Instancia.EliminarProducto(producto.id_producto);
            if (exito)
                return RedirectToAction("Listar");

            ModelState.AddModelError("", "No se pudo eliminar el producto.");
            return View(producto);
        }

        // ========================
        // 👉 MÉTODO AUXILIAR PARA CARGAR DROPDOWNS
        // ========================
        private ProductoViewModel CargarViewModel(ProductoViewModel vm)
        {
            vm.Proveedores = logProveedores.Instancia.ListarProveedores()
                .Select(p => new SelectListItem
                {
                    Value = p.id_proveedor.ToString(),
                    Text = p.razon_social
                }).ToList();

            vm.Categorias = logCategoria.Instancia.ListarCategorias()
                .Select(c => new SelectListItem
                {
                    Value = c.idCategoria.ToString(),
                    Text = c.nombreCategoria
                }).ToList();

            vm.Presentaciones = logPresentacion.Instancia.ListarPresentaciones()
                .Select(pr => new SelectListItem
                {
                    Value = pr.idPresentacion.ToString(),
                    Text = pr.nombrePresentacion
                }).ToList();

            vm.TiposEmpaque = logTipoEmpaque.Instancia.ListarTipoEmpaque()
                .Select(te => new SelectListItem
                {
                    Value = te.idTipoEmpaque.ToString(),
                    Text = te.nombreEmpaque
                }).ToList();

            return vm;
        }
    }
}
