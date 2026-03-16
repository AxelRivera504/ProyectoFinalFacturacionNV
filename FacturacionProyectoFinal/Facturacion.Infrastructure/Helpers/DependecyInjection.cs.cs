using Facturacion.Application.Intefaces.Productos;
using Facturacion.Infrastructure.Context;
using Facturacion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Helpers
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            //Agregando cadena de conexión a nuestra BD.
            services.AddDbContext<FacturacionContext>(options => options.UseSqlServer(configuration["LocalConnectionString"]));

            //Agregando Repositories
            services.AddScoped<IProductoRepository, ProductoRepository>();
            return services;
        }
    }
}
