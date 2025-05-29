using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entUsuario
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } 
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; } = true;

        public string NombreMostrar =>
            Empleado != null ? Empleado.NombreCompleto : NombreUsuario;
    }
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string NumeroDocumento { get; set; } 
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoPersonal { get; set; }
        public string Telefono { get; set; }
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Puesto { get; set; }
        public bool Estado { get; set; } = true;

        public entUsuario Usuario { get; set; }

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
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
