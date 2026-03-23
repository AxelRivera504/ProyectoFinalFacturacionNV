namespace Facturacion.Application.DTOs.Productos
{
    public class CrearProductoRequestDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public int UsuarioCreacion { get; set; }
    }
}
