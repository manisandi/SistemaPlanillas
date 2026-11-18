namespace SistemaPlanillas.Models
{
    public class Vacacion
    {
        public int IdVacacion { get; set; }

        public int IdEmpleado { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public decimal DiasSolicitados { get; set; }

        public string? Observaciones { get; set; }

        public string Estado { get; set; } = string.Empty;
    }
}