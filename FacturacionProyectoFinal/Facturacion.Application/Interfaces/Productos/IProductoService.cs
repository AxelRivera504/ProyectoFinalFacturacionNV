using Facturacion.Application.DTOs.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Interfaces.Productos
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDto>> ObtenerProductosAsync();
        Task<ProductoResponseDto?> ObtenerProductoPorIdAsync(int id);
        Task<ProductoResponseDto> AgregarAsync(CrearProductoRequestDto dto);
        Task<ProductoResponseDto?> ActualizarAsync(int id, EditarProductoRequestDto dto);
    }
}
