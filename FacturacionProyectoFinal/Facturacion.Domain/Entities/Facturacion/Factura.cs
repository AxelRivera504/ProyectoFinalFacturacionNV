namespace Facturacion.Domain.Entities.Facturacion
{
    public class Factura : EntidadBase
    {
        public DateTime FechaFactura { get; set; } = DateTime.UtcNow;
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
    }
}
