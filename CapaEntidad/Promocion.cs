using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Promocion
    {
        public int PromocionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public List<CondicionPromocion> Condiciones { get; set; }
        public List<AccionPromocion> Acciones { get; set; }

        public bool EstaVigente()
        {
            var ahora = DateTime.Now;
            return Estado &&
                   (!FechaInicio.HasValue || FechaInicio <= ahora) &&
                   (!FechaFin.HasValue || FechaFin >= ahora);
        }
    }

    public class CondicionPromocion
    {
        public int CondicionId { get; set; }
        public int PromocionId { get; set; }
        public string TipoCondicion { get; set; }
        public string CampoReferencia { get; set; }
        public string Operador { get; set; } 
        public string Valor { get; set; }
    }

    public class AccionPromocion
    {
        public int AccionId { get; set; }
        public int PromocionId { get; set; }
        public string TipoAccion { get; set; } 
        public int? ProductoObjetivoId { get; set; }
        public entPresentacion ProductoObjetivo { get; set; }
        public decimal Valor { get; set; }
    }
}
