namespace Facturacion.Domain.Entities.Autorizacion
{
    public class Pantalla : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public string RutaPantalla { get; set; } = string.Empty;
        public ICollection<RolPantalla> RolPantallas { get; set; } = new List<RolPantalla>();

    }
}
