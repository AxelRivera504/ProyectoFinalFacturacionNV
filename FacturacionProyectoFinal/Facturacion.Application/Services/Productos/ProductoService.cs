using Facturacion.Application.Converters.Productos;
using Facturacion.Application.DTOs.Productos;
using Facturacion.Application.Intefaces.Productos;
using Facturacion.Application.Interfaces.Productos;
using Facturacion.Domain.Entities.Facturacion;
using FluentValidation;

namespace Facturacion.Application.Services.Productos
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IValidator<CrearProductoRequestDto> _validator;
        private readonly IValidator<EditarProductoRequestDto> _validatorEditar;
        public ProductoService(IProductoRepository productoRepository, IValidator<CrearProductoRequestDto> validator, IValidator<EditarProductoRequestDto> validatorEditar)
        {
            _productoRepository = productoRepository;
            _validator = validator;
            _validatorEditar = validatorEditar;
        }
        public async Task<bool> ActualizarAsync(int id, EditarProductoRequestDto dto)
        {
            var validations = await _validatorEditar.ValidateAsync(dto);
            if (!validations.IsValid)
            {
                //Devolver lista de errores que nos devuelve el validator
                var errors = validations.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                throw new Exception(errors.ToString());
            }

            try
            {
                var producto = await _productoRepository.ObtenerProductoPorIdAsync(id);
                if (producto is null)
                    throw new Exception("El producto que se desea editar no existe en la BD");

                //Mapeo del dto a entidad con el trace de EF
                producto.Stock = dto.Stock;
                producto.FechaModificacion = DateTime.Now;
                producto.ImageUrl = dto.ImageUrl;
                producto.UsuarioModificacion = dto.UsuarioModificacion;
                producto.Precio = dto.Precio;
                producto.Nombre = dto.Nombre;
                producto.UnidadMedida = dto.UnidadMedida;

                //Actualizamos el producto en cache
                _productoRepository.ActualizarAsync(producto);

                //Aplicamos los cambios en la BD
                return await _productoRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AgregarAsync(CrearProductoRequestDto dto)
        {
            var validations = await _validator.ValidateAsync(dto);
            if (!validations.IsValid)
            {
                //Devolver lista de errores que nos devuelve el validator
                var errors = validations.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                throw new Exception(errors.ToString());
            }

            try
            {
                //Agregamos el producto en la cache
                await _productoRepository.AgregarAsync(dto.ToEntity());

                //Aplicamos en la BD
                return await _productoRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductoResponseDto?> ObtenerProductoPorIdAsync(int id)
        {
            var productos = await _productoRepository.ObtenerProductoPorIdAsync(id);
            return productos.ToResponseDto();
        }

        public async Task<IEnumerable<ProductoResponseDto>> ObtenerProductosAsync()
        {
            var productos = await _productoRepository.ObtenerProductosAsync();

            return productos.Select(p => new ProductoResponseDto
            {
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
