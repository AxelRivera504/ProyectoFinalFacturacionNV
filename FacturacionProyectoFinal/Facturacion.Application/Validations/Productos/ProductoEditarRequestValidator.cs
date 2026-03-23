using Facturacion.Application.DTOs.Productos;
using FluentValidation;

namespace Facturacion.Application.Validations.Productos
{
    public class ProductoEditarRequestValidator : AbstractValidator<EditarProductoRequestDto>
    {
        public ProductoEditarRequestValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es requerido")
                .MaximumLength(150).WithMessage("El nombre del producto no puede superar 150 caracteres");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(500).WithMessage("La url de la imagen del producto no puede superar 500 caracteres")
                .When(x => !string.IsNullOrEmpty(x.ImageUrl));

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio del producto debe ser mayor a 0");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo");

            RuleFor(x => x.UnidadMedida)
                .NotEmpty().WithMessage("La unidad de medida es requerida")
                .MaximumLength(150).WithMessage("La unidad de medida del producto no puede superar 30 caracteres");
        }
    }
}
