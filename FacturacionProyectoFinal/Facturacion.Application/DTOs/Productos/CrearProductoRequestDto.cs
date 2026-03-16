using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.DTOs.Productos
{
    public class CrearProductoRequestDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string  UnidadMedidad { get; set; } = string.Empty;
    }
}
