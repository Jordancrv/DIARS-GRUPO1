using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SantaEulalia.ViewModels;
using System;
using System.Linq;

namespace SantaEulalia.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Listar todos los productos
        public IActionResult Listar()
        {
            var productos = logProducto.Instancia.ListarProducto();
            return View(productos);
        }

        // GET: Mostrar detalles de un producto por ID
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            try
            {
                var producto = logProducto.Instancia.BuscarProducto(id);
                if (producto == null)
                    return NotFound();

                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al mostrar detalles: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // GET: Mostrar formulario para registrar un nuevo producto
        [HttpGet]
        public IActionResult Registrar()
        {
            var viewModel = new ProductoViewModel();
            CargarCombos(viewModel);
            return View(viewModel);
        }

        // POST: Insertar nuevo producto
        [HttpPost]
        public IActionResult Registrar(ProductoViewModel vm)
        {
            try
            {
                bool registrado = logProducto.Instancia.InsertarProducto(vm.Producto);

                if (registrado)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo registrar el producto.";
                CargarCombos(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar: " + ex.Message;
                CargarCombos(vm);
                return View(vm);
            }
        }

        // GET: Mostrar formulario para editar un producto
        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var producto = logProducto.Instancia.BuscarProducto(id);
                if (producto == null)
                    return NotFound();

                var viewModel = new ProductoViewModel
                {
                    Producto = producto
                };
                CargarCombos(viewModel);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar datos del producto: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Actualizar producto
        [HttpPost]
        public IActionResult Editar(ProductoViewModel vm)
        {
            try
            {
                bool editado = logProducto.Instancia.EditarProducto(vm.Producto);

                if (editado)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo editar el producto.";
                CargarCombos(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar: " + ex.Message;
                CargarCombos(vm);
                return View(vm);
            }
        }

        // GET: Mostrar confirmación para eliminar producto
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var producto = logProducto.Instancia.BuscarProducto(id);
                if (producto == null)
                    return NotFound();

                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al buscar producto: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Confirmar eliminación
        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            try
            {
                bool eliminado = logProducto.Instancia.EliminarProducto(id);
                if (eliminado)
                    return RedirectToAction("Listar");

                ViewBag.Error = "No se pudo eliminar el producto.";
                var producto = logProducto.Instancia.BuscarProducto(id);
                return View("Eliminar", producto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar: " + ex.Message;
                var producto = logProducto.Instancia.BuscarProducto(id);
                return View("Eliminar", producto);
            }
        }

        // Método privado para cargar los combos en el ViewModel
        private void CargarCombos(ProductoViewModel vm)
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
                .Select(p => new SelectListItem
                {
                    Value = p.idPresentacion.ToString(),
                    Text = p.nombrePresentacion
                }).ToList();

            vm.TiposEmpaque = logTipoEmpaque.Instancia.ListarTipoEmpaque()
                .Select(t => new SelectListItem
                {
                    Value = t.idTipoEmpaque.ToString(),
                    Text = t.nombreEmpaque
                }).ToList();
        }
    }
}
