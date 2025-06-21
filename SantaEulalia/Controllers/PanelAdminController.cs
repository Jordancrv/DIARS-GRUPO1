using Microsoft.AspNetCore.Mvc;

public class PanelAdminController : Controller
{
    public IActionResult Index()
    {
        var rol = HttpContext.Session.GetString("rol");
        if (rol != "admin")
        {
            return RedirectToAction("Index", "Login");
        }

        // Lógica del panel admin...
        return View();
    }

}
