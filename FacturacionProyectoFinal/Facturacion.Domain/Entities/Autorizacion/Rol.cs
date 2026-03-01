namespace Facturacion.Domain.Entities.Autorizacion
{
    public class Rol : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
        public ICollection<RolPantalla> rolPantallas { get; set; } = new List<RolPantalla>();
    }
}
