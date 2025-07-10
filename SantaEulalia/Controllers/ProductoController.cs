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
        // 👉 VISTA PARA ADMINISTRADOR (Listar Productos)
        // ========================
        [HttpGet]
        public IActionResult Listar()
        {
            var productos = logProducto.Instancia.ListarProducto();
            return View(productos); // ← Asegúrate de tener la vista Views/Producto/Listar.cshtml
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            // 1. Creamos la instancia del ViewModel
            var vm = new ProductoViewModel
            {
                Producto = new entProductos(),  // en caso de que tu VM lo requiera
                Proveedores = logProveedores.Instancia.ListarProveedores()
                               .Select(p => new SelectListItem
                               {
                                   Value = p.id_proveedor.ToString(),
                                   Text = p.razon_social
                               })
                               .ToList(),

                Categorias = logCategoria.Instancia.ListarCategorias()
                               .Select(c => new SelectListItem
                               {
                                   Value = c.idCategoria.ToString(),
                                   Text = c.nombreCategoria
                               })
                               .ToList(),

                Presentaciones = logPresentacion.Instancia.ListarPresentaciones()
                               .Select(pr => new SelectListItem
                               {
                                   Value = pr.idPresentacion.ToString(),
                                   Text = pr.nombrePresentacion
                               })
                               .ToList(),

                TiposEmpaque = logTipoEmpaque.Instancia.ListarTipoEmpaque()
                               .Select(te => new SelectListItem
                               {
                                   Value = te.idTipoEmpaque.ToString(),
                                   Text = te.nombreEmpaque
                               })
                               .ToList()
            };

            ViewData["Title"] = "Registrar Producto";
            return View(vm);
        }
        // Llamada a la capa de negocio para guardar el producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ProductoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // Recargamos las listas exactamente igual que en el GET
                vm.Proveedores = logProveedores.Instancia.ListarProveedores()
                    .Select(p => new SelectListItem
                    {
                        Value = p.id_proveedor.ToString(),
                        Text = p.razon_social
                    })
                    .ToList();

                vm.Categorias = logCategoria.Instancia.ListarCategorias()
                    .Select(c => new SelectListItem
                    {
                        Value = c.idCategoria.ToString(),
                        Text = c.nombreCategoria
                    })
                    .ToList();

                vm.Presentaciones = logPresentacion.Instancia.ListarPresentaciones()
                    .Select(pr => new SelectListItem
                    {
                        Value = pr.idPresentacion.ToString(),
                        Text = pr.nombrePresentacion
                    })
                    .ToList();

                vm.TiposEmpaque = logTipoEmpaque.Instancia.ListarTipoEmpaque()
                    .Select(te => new SelectListItem
                    {
                        Value = te.idTipoEmpaque.ToString(),
                        Text = te.nombreEmpaque 
                    })
                    .ToList();

                ViewData["Title"] = "Registrar Producto";
                return View(vm);
            }

            bool exito = logProducto.Instancia.InsertarProducto(vm.Producto);
            if (exito)
                return RedirectToAction("Listar");

            ModelState.AddModelError("", "No se pudo registrar el producto.");

            // Recargamos las listas de nuevo para volver a mostrar la vista
            vm.Proveedores = logProveedores.Instancia.ListarProveedores()
                .Select(p => new SelectListItem
                {
                    Value = p.id_proveedor.ToString(),
                    Text = p.razon_social
                })
                .ToList();

            vm.Categorias = logCategoria.Instancia.ListarCategorias()
                .Select(c => new SelectListItem
                {
                    Value = c.idCategoria.ToString(),
                    Text = c.nombreCategoria
                })
                .ToList();

            vm.Presentaciones = logPresentacion.Instancia.ListarPresentaciones()
                .Select(pr => new SelectListItem
                {
                    Value = pr.idPresentacion.ToString(),
                    Text = pr.nombrePresentacion
                })
                .ToList();

            vm.TiposEmpaque = logTipoEmpaque.Instancia.ListarTipoEmpaque()
                .Select(te => new SelectListItem
                {
                    Value = te.idTipoEmpaque.ToString(),
                    Text = te.nombreEmpaque
                })
                .ToList();

            ViewData["Title"] = "Registrar Producto";
            return View(vm);
        }



    }
}
