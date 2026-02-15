namespace Facturacion.Domain.Entities.Facturacion
{
    public class FacturaDetalle : EntidadBase
    {
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
