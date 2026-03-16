using Facturacion.Application.Intefaces.Productos;
using Facturacion.Application.Interfaces.Productos;
using Facturacion.Application.Services.Productos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Helpers
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {

            //Agregando Repositories
            services.AddScoped<IProductoService, ProductoService>();
            return services;
        }
    }
}
