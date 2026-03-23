namespace Facturacion.Application.DTOs.Productos
{
    public class ProductoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
