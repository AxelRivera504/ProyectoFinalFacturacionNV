using Facturacion.Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Intefaces.Productos
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductosAsync();
        Task<Producto?> ObtenerProductoPorIdAsync(int id);
        Task AgregarAsync(Producto producto);
        void ActualizarAsync(Producto producto);
    }
}
