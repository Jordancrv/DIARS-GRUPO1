using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaLogica;
namespace SantaEulalia.Controllers
{
    public class ControllerVenta : Controller
    {

        // GET: ControllerVenta
        public IActionResult Listar()
        {
            var listaVentas = logVenta.Instancia.ListarVentas();
            return View(listaVentas);
        }

        // GET: ControllerVenta/Details/5
        public IActionResult Details(int id)
        {
            var venta = logVenta.Instancia.BuscarVenta(id);
            return View(venta);
        }

        // GET: ControllerVenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControllerVenta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(entPedidosVenta venta)
        {
            try
            {
                int idVenta;
                string mensaje;
                bool resultado = logVenta.Instancia.InsertarVenta(venta, out idVenta, out mensaje);

                if (resultado)
                    return RedirectToAction(nameof(Listar));
                else
                {
                    ViewBag.Mensaje = mensaje;
                    return View(venta);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ControllerVenta/Edit/5
        public IActionResult Edit(int id)
        {
            var venta = logVenta.Instancia.BuscarVenta(id);
            return View(venta);
        }

        // POST: ControllerVenta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(entPedidosVenta venta)
        {
            try
            {
                bool resultado = logVenta.Instancia.EditarVenta(venta);

                if (resultado)
                    return RedirectToAction(nameof(Listar));
                else
                    return View(venta);
            }
            catch
            {
                return View();
            }
        }

        // GET: ControllerVenta/Delete/5
        public IActionResult Delete(int id)
        {
            var venta = logVenta.Instancia.BuscarVenta(id);
            return View(venta);
        }

        // POST: ControllerVenta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                logVenta.Instancia.EliminarVenta(id);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
