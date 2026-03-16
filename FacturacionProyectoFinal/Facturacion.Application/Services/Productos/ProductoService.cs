using Facturacion.Application.DTOs.Productos;
using Facturacion.Application.Intefaces.Productos;
using Facturacion.Application.Interfaces.Productos;
using Facturacion.Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Services.Productos
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;  
        }
        public Task<ProductoResponseDto?> ActualizarAsync(int id, EditarProductoRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoResponseDto> AgregarAsync(CrearProductoRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoResponseDto?> ObtenerProductoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductoResponseDto>> ObtenerProductosAsync()
        {
            var productos = await _productoRepository.ObtenerProductosAsync();

            return productos.Select(p => new ProductoResponseDto { 
                EstaActivo = true,
                UnidadMedida = p.UnidadMedida,
                FechaCreacion = p.FechaCreacion,
                Id = p.Id,
                ImageUrl = p.ImageUrl,  
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock 
            });
        }

        // Método privado de mapeo — reutilizable dentro del servicio
        // (alternativa a librerías como AutoMapper)
        private static ProductoResponseDto MapToResponse(Producto p) => new()
        {
            Id = p.Id,
            Nombre = p.Nombre,
            ImageUrl = p.ImageUrl,
            Precio = p.Precio,
            Stock = p.Stock,
            UnidadMedida = p.UnidadMedida,
            EstaActivo = p.EstaActivo,
            FechaCreacion = p.FechaCreacion
        };
    }
}
