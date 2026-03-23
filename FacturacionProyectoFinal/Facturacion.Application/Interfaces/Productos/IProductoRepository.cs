using Facturacion.Domain.Entities.Facturacion;

namespace Facturacion.Application.Intefaces.Productos
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductosAsync();
        Task<Producto?> ObtenerProductoPorIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task AgregarAsync(Producto producto);
        void ActualizarAsync(Producto producto);
    }
}
