using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaLogica;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace SantaEulalia.Controllers
{
    public class CarritoController : Controller
    {
        [HttpPost]
        public IActionResult AgregarCarrito(int id, int cantidad)
        {
            var producto = logProducto.Instancia.BuscarProducto(id);
            if (producto == null)
                return NotFound();

            var carrito = HttpContext.Session.GetObjectFromJson<List<entDetalleVenta>>("carrito")
                          ?? new List<entDetalleVenta>();

            var itemExistente = carrito.FirstOrDefault(x => x.IdProducto == id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
                itemExistente.Subtotal = itemExistente.Cantidad * itemExistente.PrecioUnitario;
                itemExistente.TotalConDescuento = itemExistente.Subtotal * (1 - itemExistente.Descuento / 100);
            }
            else
            {
                decimal subtotal = producto.precioventa * cantidad;
                decimal descuento = 0; // Aquí puedes aplicar lógica de promoción si deseas

                var detalle = new entDetalleVenta
                {
                    IdProducto = producto.id_producto,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.precioventa,
                    Subtotal = subtotal,
                    Descuento = descuento,
                    TotalConDescuento = subtotal * (1 - descuento / 100),
                    Producto = producto // ✅ Aquí se asigna el producto completo
                };

                carrito.Add(detalle);
            }

            HttpContext.Session.SetObjectAsJson("carrito", carrito);

            return RedirectToAction("Tienda", "Producto");
        }

        public IActionResult Index()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entDetalleVenta>>("carrito")
                          ?? new List<entDetalleVenta>();

            return View(carrito);
        }

        public IActionResult Eliminar(int id)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<entDetalleVenta>>("carrito")
                          ?? new List<entDetalleVenta>();

            var item = carrito.FirstOrDefault(x => x.IdProducto == id);
            if (item != null)
                carrito.Remove(item);

            HttpContext.Session.SetObjectAsJson("carrito", carrito);
            return RedirectToAction("Index");
        }

        public IActionResult Vaciar()
        {
            HttpContext.Session.Remove("carrito");
            return RedirectToAction("Index");
        }
    }
}
