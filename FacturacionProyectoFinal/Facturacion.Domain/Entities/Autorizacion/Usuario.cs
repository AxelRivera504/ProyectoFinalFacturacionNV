namespace Facturacion.Domain.Entities.Acceso
{
    public class Usuario : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
