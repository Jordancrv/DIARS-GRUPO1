using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Listar todos los usuarios
        public IActionResult Listar()
        {
            var listaUsuarios = logUsuario.Instancia.Listar();
            ViewBag.Lista = listaUsuarios;
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            return View(new entUsuario());
        }


        [HttpPost]
        public ActionResult Registrar(entUsuario usuario)
        {
            try
            {
                usuario.fecha_creacion = DateTime.Now;

                // Elimina correos nulos o vacíos
                usuario.correos = usuario.correos?
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .ToList();

                Console.WriteLine("Correos válidos recibidos:");
                foreach (var c in usuario.correos)
                    Console.WriteLine(c);

                bool exito = logUsuario.Instancia.Registrar(usuario);
                if (exito)
                    return RedirectToAction("Listar");
                else
                    return View(usuario); // Devuelve la vista con los datos si falla
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View(usuario);
            }
        }
    }   
}

