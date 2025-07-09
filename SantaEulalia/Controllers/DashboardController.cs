using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SantaEulalia.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
