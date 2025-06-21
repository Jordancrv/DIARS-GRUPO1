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
            HttpContext.Session.SetString("nombres_usuario", usuario.nombres);
            HttpContext.Session.SetString("rol", usuario.rol);

            if (usuario.rol == "admin")
                return RedirectToAction("Index", "PanelAdmin"); // Usa _Layout.cshtml
            else
                return RedirectToAction("PanelUser", "Home"); // Usa _LayoutUser.cshtml
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
