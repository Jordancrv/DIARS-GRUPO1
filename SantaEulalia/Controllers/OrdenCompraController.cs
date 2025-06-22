using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapaEntidad;
using CapaLogica;
using System.Collections.Generic;

public class OrdenCompraController : Controller
{
    // GET: /OrdenCompra/Listar
    public IActionResult Listar()
    {
        var lista = logOrdenCompra.Instancia.ListarOrdenesCompra(); // Método en lógica que lista todas las órdenes
        return View(lista);
    }

    // GET: /OrdenCompra/Crear
    public IActionResult Crear()
    {
        ViewBag.Proveedores = new SelectList(logProveedores.Instancia.ListarProveedores(), "id_proveedor", "razon_social");
        ViewBag.Productos = logProducto.Instancia.ListarProducto(); // En la vista se recorre como List<entProductos>
        return View(new OrdenCompra());
    }

    // POST: /OrdenCompra/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(OrdenCompra orden)
    {
        if (ModelState.IsValid)
        {
            try
            {
                bool ok = logOrdenCompra.Instancia.InsertarOrdenCompraCompleta(orden);
                if (ok)
                    return RedirectToAction("Listar");

                ModelState.AddModelError("", "No se pudo registrar la orden.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); // << Aquí muestra "Uno o más productos no tienen precio pactado con el proveedor."
            }
        }

        ViewBag.Proveedores = new SelectList(logProveedores.Instancia.ListarProveedores(), "id_proveedor", "razon_social");
        ViewBag.Productos = logProducto.Instancia.ListarProducto();
        return View(orden);
    }
    public IActionResult Details(int id)
    {
        var orden = logOrdenCompra.Instancia.ObtenerOrdenCompraPorId(id);
        if (orden == null)
        {
            return NotFound();
        }

        return View(orden);
    }



    // GET: /OrdenCompra/Anular/id
    public IActionResult Anular(int id)
    {
        bool result = logOrdenCompra.Instancia.AnularOrdenCompra(id);
        if (!result)
        {
            TempData["Error"] = "No se pudo anular la orden o ya está procesada.";
        }
        return RedirectToAction("Listar");
    }
}
