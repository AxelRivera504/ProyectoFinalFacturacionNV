using Facturacion.Domain.Entities.Autorizacion;

namespace Facturacion.Domain.Entities
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public int? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public Usuario? UsuarioCrea { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Usuario? UsuarioModf { get; set; }
        public bool EstaActivo { get; set; }
    }
}
