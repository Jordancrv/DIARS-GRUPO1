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

        // GET: Mostrar detalles de un usuario por ID
        //[HttpGet]
        //public IActionResult Detalles(int id)
        //{
        //    try
        //    {
        //        var usuario = logUsuario.Instancia.BuscarPorId(id);
        //        if (usuario == null)
        //            return NotFound();

        //        return View(usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return RedirectToAction("Listar");
        //    }
        //}

        //// GET: Mostrar formulario para registrar usuario
        //[HttpGet]
        //public IActionResult Registrar()
        //{
        //    return View();
        //}

        //// POST: Insertar nuevo usuario en la BD
        //[HttpPost]
        //public IActionResult Registrar(entUsuario usuario)
        //{
        //    try
        //    {
        //        bool resultado = logUsuario.Instancia.Registrar(usuario);

        //        if (resultado)
        //            return RedirectToAction("Listar");
        //        else
        //        {
        //            ViewBag.Error = "No se pudo registrar el usuario.";
        //            return View(usuario);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return View(usuario);
        //    }
        //}
        // GET: Mostrar formulario para registrar usuario


    }
    //public IActionResult InsertarCliente(entClientes cliente)
    //   {
    //       try
    //       {
    //           int idGenerado = logClientes.Instancia.InsertarCliente2(cliente);

    //           if (idGenerado > 0)
    //               return RedirectToAction("Listar");

    //           ViewBag.Error = "No se pudo registrar el cliente.";
    //           return View(cliente);
    //       }
    //       catch (Exception ex)
    //       {
    //           ViewBag.Error = "Error: " + ex.Message;
    //           return View(cliente);
    //       }






    //// GET: Mostrar formulario para editar usuario
    //[HttpGet]
    //public IActionResult Editar(int id)
    //{
    //    try
    //    {
    //        var usuario = logUsuario.Instancia.BuscarPorId(id);
    //        if (usuario == null)
    //            return NotFound();

    //        return View(usuario);
    //    }
    //    catch (Exception ex)
    //    {
    //        ViewBag.Error = "Error: " + ex.Message;
    //        return RedirectToAction("Listar");
    //    }
    //}

    //// POST: Actualizar usuario en la BD
    //[HttpPost]
    //public IActionResult Editar(entUsuario usuario)
    //{
    //    try
    //    {
    //        bool resultado = logUsuario.Instancia.Editar(usuario);

    //        if (resultado)
    //            return RedirectToAction("Listar");
    //        else
    //            return View(usuario);
    //    }
    //    catch (Exception ex)
    //    {
    //        ViewBag.Error = "Error: " + ex.Message;
    //        return View(usuario);
    //    }
    //}

    //// GET: Mostrar confirmación para eliminar usuario
    //[HttpGet]
    //public IActionResult Eliminar(int id)
    //{
    //    try
    //    {
    //        var usuario = logUsuario.Instancia.BuscarPorId(id);
    //        if (usuario == null)
    //            return NotFound();

    //        return View(usuario);
    //    }
    //    catch (Exception ex)
    //    {
    //        ViewBag.Error = "Error: " + ex.Message;
    //        return RedirectToAction("Listar");
    //    }
    //}

    //// POST: Confirmar eliminación del usuario
    //[HttpPost, ActionName("Eliminar")]
    //public IActionResult EliminarConfirmado(int id)
    //{
    //    try
    //    {
    //        bool eliminado = logUsuario.Instancia.Eliminar(id);
    //        if (eliminado)
    //            return RedirectToAction("Listar");
    //        else
    //        {
    //            ViewBag.Error = "No se pudo eliminar el usuario.";
    //            var usuario = logUsuario.Instancia.BuscarPorId(id);
    //            return View("Eliminar", usuario);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ViewBag.Error = "Error: " + ex.Message;
    //        var usuario = logUsuario.Instancia.BuscarPorId(id);
    //        return View("Eliminar", usuario);
    //    }
    //}


}

