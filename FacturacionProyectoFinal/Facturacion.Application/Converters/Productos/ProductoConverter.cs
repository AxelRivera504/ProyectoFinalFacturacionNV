using Facturacion.Application.DTOs.Productos;
using Facturacion.Domain.Entities.Facturacion;

namespace Facturacion.Application.Converters.Productos
{
    public static class ProductoConverter
    {
        public static ProductoResponseDto ToResponseDto(this Producto producto)
        {
            if (producto is null) throw new ArgumentNullException(nameof(producto));

            return new ProductoResponseDto()
            {
                EstaActivo = producto.EstaActivo,
                FechaCreacion = producto.FechaCreacion,
                Id = producto.Id,
                ImageUrl = producto.ImageUrl,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                UnidadMedida = producto.UnidadMedida
            };
        }

        public static Producto ToEntity(this CrearProductoRequestDto producto)
        {
            if (producto is null) throw new ArgumentNullException(nameof(producto));

            return new Producto()
            {
                ImageUrl = producto.ImageUrl,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                UnidadMedida = producto.UnidadMedida,
                EstaActivo = true,
                UsuarioCreacion = producto.UsuarioCreacion,
                FechaCreacion = DateTime.Now
            };
        }

        public static Producto ToEntityEditar(this EditarProductoRequestDto producto)
        {
            if (producto is null) throw new ArgumentNullException(nameof(producto));

            return new Producto()
            {
                Id = producto.Id,
                ImageUrl = producto.ImageUrl,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                UnidadMedida = producto.UnidadMedida,
                UsuarioModificacion = producto.UsuarioModificacion,
                FechaModificacion = DateTime.Now
            };
        }
    }
}
