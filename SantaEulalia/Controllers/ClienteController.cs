using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class ClienteController : Controller
    {
       
        
            // GET: Listar clientes activos
            public IActionResult Listar()
            {
                var listaClientes = logClientes.Instancia.ListarCliente(); // Usa sp_ListarClienteCompleto
                ViewBag.Lista = listaClientes;
                return View(listaClientes);
            }

            // GET: Detalles
            [HttpGet]
            public IActionResult Detalles(int id)
            {
                try
                {
                    var cliente = logClientes.Instancia.BuscarCliente(id); // Usa sp_BuscarCliente
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

            // POST: Insertar cliente
            [HttpPost]
            public IActionResult InsertarCliente(entClientes cliente)
            {
                try
                {
                    bool resultado = logClientes.Instancia.InsertarCliente(cliente); // Usa lógica con listas
                    if (resultado)
                        return RedirectToAction("Listar");

                    ViewBag.Error = "No se pudo registrar el cliente.";
                    return View(cliente);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(cliente);
                }
            }

            // GET: Mostrar formulario de edición
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

            // POST: Editar cliente
            [HttpPost]
            public IActionResult EditarCliente(entClientes cliente)
            {
                try
                {
                    bool resultado = logClientes.Instancia.EditarCliente(cliente); // Elimina e inserta correos/teléfonos
                    if (resultado)
                        return RedirectToAction("Listar");

                    ViewBag.Error = "No se pudo actualizar el cliente.";
                    return View(cliente);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(cliente);
                }
            }

            // GET: Mostrar confirmación de eliminación
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

            // POST: Confirmar eliminación (borrado lógico)
            [HttpPost, ActionName("EliminarCliente")]
            public IActionResult EliminarClienteConfirmado(int id)
            {
                try
                {
                    bool eliminado = logClientes.Instancia.EliminarCliente(id); // Usa sp_EliminarCliente (activo = 0)
                    if (eliminado)
                        return RedirectToAction("Listar");

                    ViewBag.Error = "No se pudo eliminar el cliente.";
                    var cliente = logClientes.Instancia.BuscarCliente(id);
                    return View("EliminarCliente", cliente);
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

