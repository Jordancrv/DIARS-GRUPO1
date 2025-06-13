using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Listar todos los productos
        public IActionResult Listar()
        {
            var productos = logProducto.Instancia.ListarProducto();
            ViewBag.Lista = productos;
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
            return View();
        }

        // POST: Insertar nuevo producto
        [HttpPost]
        public IActionResult Registrar(entProductos producto)
        {
            try
            {
                bool registrado = logProducto.Instancia.InsertarProducto(producto);

                if (registrado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo registrar el producto.";
                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar: " + ex.Message;
                return View(producto);
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

                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar datos del producto: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Actualizar producto
        [HttpPost]
        public IActionResult Editar(entProductos producto)
        {
            try
            {
                bool editado = logProducto.Instancia.EditarProducto(producto);

                if (editado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo editar el producto.";
                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar: " + ex.Message;
                return View(producto);
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
                else
                {
                    ViewBag.Error = "No se pudo eliminar el producto.";
                    var producto = logProducto.Instancia.BuscarProducto(id);
                    return View("Eliminar", producto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar: " + ex.Message;
                var producto = logProducto.Instancia.BuscarProducto(id);
                return View("Eliminar", producto);
            }
        }





    }
}
