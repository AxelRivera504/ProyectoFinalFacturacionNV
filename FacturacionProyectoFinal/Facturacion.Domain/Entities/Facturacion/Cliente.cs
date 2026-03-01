namespace Facturacion.Domain.Entities.Facturacion
{
    public class Cliente : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string? telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; } = string.Empty;

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
