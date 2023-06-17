namespace RecaudosAPI.Models
{
    public class Recaudos
    {
        public int Id { get; set; }
        public string? estacion { get; set; }
        public string? sentido { get; set; }
        public int hora { get; set; }
        public string? categoria { get; set; }
        public int cantidad { get; set; }
        public int valorTabulado { get; set; }
    }
}
