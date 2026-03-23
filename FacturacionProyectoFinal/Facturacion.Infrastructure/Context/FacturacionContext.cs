using Facturacion.Domain.Entities.Autorizacion;
using Facturacion.Domain.Entities.Facturacion;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Infrastructure.Context
{
    public partial class FacturacionContext : DbContext
    {
        public FacturacionContext() { }

        public FacturacionContext(DbContextOptions options) : base(options)
        {
        }

        // Autorizacion
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Pantalla> Pantallas => Set<Pantalla>();
        public DbSet<UsuarioRol> UsuariosRoles => Set<UsuarioRol>();
        public DbSet<RolPantalla> RolesPantallas => Set<RolPantalla>();

        // Facturacion
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Factura> Facturas => Set<Factura>();
        public DbSet<FacturaDetalle> FacturasDetalles => Set<FacturaDetalle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aplica automáticamente todas las clases IEntityTypeConfiguration<T> del ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacturacionContext).Assembly);
        }

        //Segunda manera de poder aplicar los mapeos con el ensamblado
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        //}
    }
}
