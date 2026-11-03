namespace SistemaPlanillas.Models
{
    public class Puesto
    {
        public int IdPuesto { get; set; }

        public string NombrePuesto { get; set; } = string.Empty;

        public decimal SalarioBase { get; set; }

        public string?  Descripcion { get; set; }
    }
}