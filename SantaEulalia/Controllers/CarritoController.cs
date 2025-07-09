using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaLogica;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SantaEulalia.Controllers
{
    public class CarritoController : Controller
    {
        // Agrega un producto al carrito
        public IActionResult AgregarCarrito(int id)
        {
            var producto = logProducto.Instancia.BuscarProducto(id);
            if (producto == null)
                return NotFound();

            List<entProductos> carrito = HttpContext.Session.GetObjectFromJson<List<entProductos>>("carrito")
                                          ?? new List<entProductos>();

            carrito.Add(producto);
            HttpContext.Session.SetObjectAsJson("carrito", carrito);

            return RedirectToAction("Tienda", "Producto");
        }

        // Muestra los productos en el carrito
        public IActionResult Index()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entProductos>>("carrito")
                          ?? new List<entProductos>();
            return View(carrito);
        }

        // Elimina un producto del carrito por su ID
        public IActionResult Eliminar(int id)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entProductos>>("carrito")
                          ?? new List<entProductos>();

            var producto = carrito.Find(p => p.id_producto == id);
            if (producto != null)
                carrito.Remove(producto);

            HttpContext.Session.SetObjectAsJson("carrito", carrito);
            return RedirectToAction("Index");
        }

        // Vacía el carrito completamente
        public IActionResult Vaciar()
        {
            HttpContext.Session.Remove("carrito");
            return RedirectToAction("Index");
        }
    }
}
