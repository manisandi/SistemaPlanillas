namespace SistemaPlanillas.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido1 { get; set; } = string.Empty;

        public string? Apellido2 { get; set; }

        public int IdDepartamento { get; set; }

        public int IdPuesto { get; set; }
    }
}