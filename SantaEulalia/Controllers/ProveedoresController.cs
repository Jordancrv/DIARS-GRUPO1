using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using CapaEntidad;

namespace SantaEulalia.Controllers
{
    public class ProveedoresController : Controller
    { // GET: Listar todos los proveedores
        public IActionResult Listar()
        {
            var proveedores = logProveedores.Instancia.ListarProveedores();
            ViewBag.Lista = proveedores;
            return View(proveedores);
        }

        // GET: Mostrar detalles de un proveedor por ID
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            try
            {
                var proveedor = logProveedores.Instancia.BuscarProveedor(id);
                if (proveedor == null)
                    return NotFound();

                return View(proveedor);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al mostrar detalles: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // GET: Mostrar formulario para registrar un nuevo proveedor
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Insertar nuevo proveedor
        [HttpPost]
        public IActionResult Registrar(entProveedores proveedor)
        {
            try
            {
                bool registrado = logProveedores.Instancia.InsertarProveedor(proveedor);

                if (registrado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo registrar el proveedor.";
                    return View(proveedor);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar: " + ex.Message;
                return View(proveedor);
            }
        }

        // GET: Mostrar formulario para editar un proveedor
        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var proveedor = logProveedores.Instancia.BuscarProveedor(id);
                if (proveedor == null)
                    return NotFound();

                return View(proveedor);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar datos del proveedor: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Actualizar proveedor
        [HttpPost]
        public IActionResult Editar(entProveedores proveedor)
        {
            try
            {
                bool editado = logProveedores.Instancia.EditarProveedor(proveedor);

                if (editado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo editar el proveedor.";
                    return View(proveedor);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar: " + ex.Message;
                return View(proveedor);
            }
        }

        // GET: Mostrar confirmación para eliminar proveedor
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var proveedor = logProveedores.Instancia.BuscarProveedor(id);
                if (proveedor == null)
                    return NotFound();

                return View(proveedor);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al buscar proveedor: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Confirmar eliminación
        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            try
            {
                bool eliminado = logProveedores.Instancia.EliminarProveedor(id);
                if (eliminado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo eliminar el proveedor.";
                    var proveedor = logProveedores.Instancia.BuscarProveedor(id);
                    return View("Eliminar", proveedor);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar: " + ex.Message;
                var proveedor = logProveedores.Instancia.BuscarProveedor(id);
                return View("Eliminar", proveedor);
            }
        }
    }
}
