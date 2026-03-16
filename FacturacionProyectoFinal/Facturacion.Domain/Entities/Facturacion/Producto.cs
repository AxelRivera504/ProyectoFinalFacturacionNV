
namespace Facturacion.Domain.Entities.Facturacion
{
    public class Producto : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
    }
}
