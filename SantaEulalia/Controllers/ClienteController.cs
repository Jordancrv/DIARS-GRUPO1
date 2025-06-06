using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using CapaLogica; 

namespace SantaEulalia.Controllers
{
    public class ClienteController : Controller {

        // GET: Listar clientes
        public IActionResult Listar()
        {
            var listaClientes = logClientes.Instancia.ListarCliente();
            ViewBag.Lista = listaClientes;
            return View(listaClientes);
        }

        // GET: Mostrar detalles de un cliente
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            try
            {
                var cliente = logClientes.Instancia.BuscarCliente(id);
                if (cliente == null)
                    return NotFound();

                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // GET: Mostrar formulario para insertar cliente
        [HttpGet]
        public IActionResult InsertarCliente()
        {
            return View();
        }

        // POST: Insertar cliente en la BD
        [HttpPost]
        public IActionResult InsertarCliente(entClientes cliente)
        {
            try
            {
                bool resultado = logClientes.Instancia.InsertarCliente(cliente);

                if (resultado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo registrar el cliente.";
                    return View(cliente);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View(cliente);
            }
        }

        // GET: Mostrar formulario para editar cliente
        [HttpGet]
        public IActionResult EditarCliente(int id)
        {
            try
            {
                var cliente = logClientes.Instancia.BuscarCliente(id);
                if (cliente == null)
                    return NotFound();

                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Actualizar cliente en la BD
        [HttpPost]
        public IActionResult EditarCliente(entClientes cliente)
        {
            try
            {
                bool resultado = logClientes.Instancia.EditarCliente(cliente);

                if (resultado)
                    return RedirectToAction("Listar");
                else
                    return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View(cliente);
            }
        }

        // GET: Mostrar confirmación para eliminar cliente
        [HttpGet]
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                var cliente = logClientes.Instancia.BuscarCliente(id);
                if (cliente == null)
                    return NotFound();

                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }

        // POST: Confirmar eliminación de cliente
        [HttpPost, ActionName("EliminarCliente")]
        public IActionResult EliminarClienteConfirmado(int id)
        {
            try
            {
                bool eliminado = logClientes.Instancia.EliminarCliente(id);
                if (eliminado)
                    return RedirectToAction("Listar");
                else
                {
                    ViewBag.Error = "No se pudo eliminar el cliente.";
                    var cliente = logClientes.Instancia.BuscarCliente(id);
                    return View("EliminarCliente", cliente);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                var cliente = logClientes.Instancia.BuscarCliente(id);
                return View("EliminarCliente", cliente);
            }
        }









    }
}
