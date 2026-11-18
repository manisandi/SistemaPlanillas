namespace SistemaPlanillas.Models
{
    public class SaldoVacacion
    {
        public int IdSaldo { get; set; }

        public int IdEmpleado { get; set; }

        public int Anio { get; set; }

        public decimal DiasDisponibles { get; set; }

        public decimal DiasDisfrutados { get; set; }
    }
}