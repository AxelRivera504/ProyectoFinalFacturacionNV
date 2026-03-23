using Facturacion.Application.DTOs.Productos;

namespace Facturacion.Application.Interfaces.Productos
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDto>> ObtenerProductosAsync();
        Task<ProductoResponseDto?> ObtenerProductoPorIdAsync(int id);
        Task<bool> AgregarAsync(CrearProductoRequestDto dto);
        Task<bool> ActualizarAsync(int id, EditarProductoRequestDto dto);
    }
}
