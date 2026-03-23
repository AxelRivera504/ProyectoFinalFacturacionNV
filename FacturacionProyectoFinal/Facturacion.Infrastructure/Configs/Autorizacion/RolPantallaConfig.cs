using Facturacion.Domain.Entities.Autorizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Infrastructure.Configs.Autorizacion
{
    public class RolPantallaConfig : IEntityTypeConfiguration<RolPantalla>
    {
        private const string Table = "RolesPantallas";
        private const string Schema = "Aut";

        public void Configure(EntityTypeBuilder<RolPantalla> builder)
        {
            builder.ToTable(Table, Schema);
            EntidadBaseConfiguration.Apply(builder, Table);

            // Un rol no puede tener la misma pantalla duplicada
            builder.HasIndex(rp => new { rp.RolId, rp.PantallaId })
                .IsUnique()
                .HasDatabaseName("UQ_RolesPantallas_RolPantalla");

            builder.HasOne(rp => rp.Rol)
                .WithMany(r => r.rolPantallas)
                .HasForeignKey(rp => rp.RolId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RolesPantallas_Roles");

            builder.HasOne(rp => rp.Pantalla)
                .WithMany(p => p.RolPantallas)
                .HasForeignKey(rp => rp.PantallaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RolesPantallas_Pantallas");

            builder.Property(rp => rp.PuederVer)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(rp => rp.PuedeCrear)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(rp => rp.PuedeEditar)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(rp => rp.PuedeDeshabilitar)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}