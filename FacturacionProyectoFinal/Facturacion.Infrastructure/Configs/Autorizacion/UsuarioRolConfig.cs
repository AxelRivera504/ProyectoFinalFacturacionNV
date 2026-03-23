using Facturacion.Domain.Entities.Autorizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Infrastructure.Configs.Autorizacion
{
    public class UsuarioRolConfig : IEntityTypeConfiguration<UsuarioRol>
    {
        private const string Table = "UsuariosRoles";
        private const string Schema = "Aut";

        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.ToTable(Table, Schema);
            EntidadBaseConfiguration.Apply(builder, Table);

            // Un usuario no puede tener el mismo rol dos veces
            builder.HasIndex(ur => new { ur.UsuarioId, ur.RolId })
                .IsUnique()
                .HasDatabaseName("UQ_UsuariosRoles_UsuarioRol");

            builder.HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRols)
                .HasForeignKey(ur => ur.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_UsuariosRoles_Usuarios");

            builder.HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRols)
                .HasForeignKey(ur => ur.RolId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_UsuariosRoles_Roles");
        }
    }
}
