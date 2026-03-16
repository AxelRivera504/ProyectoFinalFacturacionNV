using Facturacion.Application.Intefaces.Productos;
using Facturacion.Domain.Entities.Facturacion;
using Facturacion.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly FacturacionContext _facturacionContext;
        public ProductoRepository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            // LINQ: filtramos activos y ordenamos alfabéticamente
            return await _facturacionContext.Productos
                .Where(p => p.EstaActivo)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(int id)
        {
            // FirstOrDefaultAsync devuelve null si no encuentra — ideal para manejo de 404
            return await _facturacionContext.Productos
                .Where(p => p.Id == id && p.EstaActivo)
                .FirstOrDefaultAsync();
        }
        public async Task AgregarAsync(Producto producto)
        {
            await _facturacionContext.Productos.AddAsync(producto);
        }

        public void ActualizarAsync(Producto producto)
        {
            // EF Core ya está rastreando el objeto, solo marcamos como modificado
            _facturacionContext.Productos.Update(producto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _facturacionContext.SaveChangesAsync() > 0;
        }
    }
}
