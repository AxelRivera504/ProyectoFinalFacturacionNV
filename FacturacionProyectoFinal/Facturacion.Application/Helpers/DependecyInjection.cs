using Facturacion.Application.Interfaces.Productos;
using Facturacion.Application.Services.Productos;
using Facturacion.Application.Validations.Productos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Facturacion.Application.Helpers
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {

            //Agregando Repositories
            services.AddScoped<IProductoService, ProductoService>();
            services.AddValidatorsFromAssemblyContaining<ProductoRequestValidator>();
            return services;
        }
    }
}
