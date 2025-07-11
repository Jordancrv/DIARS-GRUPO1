using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Http;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var usuario = UsuarioBL.Instancia.Login(email, password);
        if (usuario != null)
        {
            HttpContext.Session.SetInt32("id_usuario", usuario.id_usuario);
            HttpContext.Session.SetString("rol", usuario.rol);

            if (usuario.rol == "admin")
                return RedirectToAction("Index", "PanelAdmin");

            if (usuario.rol == "cliente")
                return RedirectToAction("Tienda", "Producto"); 

            // Si deseas manejar otros roles:
            return RedirectToAction("PanelUser", "Home");
        }
        if (usuario.rol == "cliente")
        {
            var cliente = logClientes.Instancia.BuscarCliente(usuario.id_usuario);
            if (cliente != null)
            {
                HttpContext.Session.SetInt32("id_cliente", cliente.id_cliente);
            }

            return RedirectToAction("PanelUser", "Home");
        }
        ViewBag.Mensaje = "Credenciales incorrectas.";
        return View("Index");
    }


    [HttpGet]
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}
