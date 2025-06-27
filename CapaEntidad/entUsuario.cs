using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad

{
    public class entUsuario
    {
        public int id_usuario { get; set; }

     
        public string nombres { get; set; }

    
        public string apellidos { get; set; }

        public string password_hash { get; set; }


        public string rol { get; set; }

        public DateTime fecha_creacion { get; set; }

        public bool activo { get; set; }

     
        public List<string> correos { get; set; }

        public entUsuario()
        {
            this.correos = new List<string>(); 
        }
    }





    public class entOrdenesCompra
    {
        public int id_orden_compra { get; set; }
        public int id_proveedor { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public decimal total { get; set; }
        public entProveedores Proveedor { get; set; }
        public entUsuario Usuario { get; set; }
        public List<entDetallesOrdenCompra> Detalles { get; set; }
    }
    public class entDetallesOrdenCompra
    {
        public int id_detalle { get; set; }
        public int id_orden_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }

        public class Direccion
        {
            public int DireccionId { get; set; }
            public string Descripcion { get; set; }
            public int DistritoId { get; set; }
            public Distrito Distrito { get; set; }

            public string UbicacionCompleta =>
                $"{Descripcion}, {Distrito?.Nombre}, {Distrito?.Provincia?.Nombre}, {Distrito?.Provincia?.Departamento?.Nombre}";
        }

        public class Distrito
        {
            public int DistritoId { get; set; }
            public int ProvinciaId { get; set; }
            public Provincia Provincia { get; set; }
            public string Nombre { get; set; }
        }

        public class Provincia
        {
            public int ProvinciaId { get; set; }
            public int DepartamentoId { get; set; }
            public Departamento Departamento { get; set; }
            public string Nombre { get; set; }
        }

        public class Departamento
        {
            public int DepartamentoId { get; set; }
            public string Nombre { get; set; }
        }
    }
}
