namespace RecaudosAPI.Models
{
    public class Estaciones
    {
        public int Id { get; set; }
        public string? estacion { get; set; }
        public int totalCantidadF { get; set; }
        public int totalValorF { get; set; }
        public DateTime fecha { get; set; }

        public List<EstacionDetalle> estacionDetalle { get; set; }

    }
}
