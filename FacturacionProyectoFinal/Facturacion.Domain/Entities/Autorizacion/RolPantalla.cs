namespace Facturacion.Domain.Entities.Acceso
{
    public class RolPantalla : EntidadBase
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
        public int PantallaId { get; set; }
        public Pantalla Pantalla { get; set; } = null!;

        public bool PuederVer { get; set; }
        public bool PuedeCrear { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeDeshabilitar { get; set; }
    }
}
