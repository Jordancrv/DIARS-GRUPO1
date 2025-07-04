using CapaEntidad;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SantaEulalia.Controllers
{
    public class PromocionesController : Controller
    {
        // GET: Listar promociones
        public IActionResult Listar()
        {
            var lista = logPromociones.Instancia.ListarPromociones(); // Usa sp_ListarPromociones
            return View(lista);
        }

        //// GET: Detalles de una promoción
        //[HttpGet]
        //public IActionResult Detalles(int id)
        //{
        //    try
        //    {
        //        var promo = logPromociones.Instancia.BuscarPromocion(id);
        //        if (promo == null)
        //            return NotFound();

        //        return View(promo);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return RedirectToAction("Listar");
        //    }
        //}

        // GET: Formulario para crear promoción
        [HttpGet]
        public IActionResult Insertar()
        {
            var tipos = logPromociones.Instancia.Listar(); // Carga los tipos desde la lógica
            ViewBag.TipoPromociones = new SelectList(tipos, "IdTipoPromocion", "NombreTipo");
            return View();
        }

        // POST: Insertar promoción
        [HttpPost]
        public IActionResult Insertar(entPromociones promo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool insertado = logPromociones.Instancia.InsertarPromocion(promo);
                    if (insertado)
                        return RedirectToAction("Listar");
                }

                ViewBag.Error = "No se pudo registrar la promoción.";
                return View(promo);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View(promo);
            }
        }

        //// GET: Formulario para editar
        //[HttpGet]
        //public IActionResult Editar(int id)
        //{
        //    var promo = logPromociones.Instancia.BuscarPromocion(id);
        //    if (promo == null)
        //        return NotFound();

        //    return View(promo);
        //}

        //// POST: Editar promoción
        //[HttpPost]
        //public IActionResult Editar(entPromocion promo)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            bool actualizado = logPromocion.Instancia.EditarPromocion(promo);
        //            if (actualizado)
        //                return RedirectToAction("Listar");
        //        }

        //        ViewBag.Error = "No se pudo actualizar la promoción.";
        //        return View(promo);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return View(promo);
        //    }
        //}

        //// GET: Confirmación de eliminación
        //[HttpGet]
        //public IActionResult Eliminar(int id)
        //{
        //    var promo = logPromocion.Instancia.BuscarPromocion(id);
        //    if (promo == null)
        //        return NotFound();

        //    return View(promo);
        //}

        //// POST: Confirmar eliminación (borrado lógico)
        //[HttpPost, ActionName("Eliminar")]
        //public IActionResult EliminarConfirmado(int id)
        //{
        //    try
        //    {
        //        bool eliminado = logPromocion.Instancia.EliminarPromocion(id);
        //        if (eliminado)
        //            return RedirectToAction("Listar");

        //        ViewBag.Error = "No se pudo eliminar la promoción.";
        //        var promo = logPromocion.Instancia.BuscarPromocion(id);
        //        return View("Eliminar", promo);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Error: " + ex.Message;
        //        var promo = logPromocion.Instancia.BuscarPromocion(id);
        //        return View("Eliminar", promo);
        //    }
        //}
    }
}
