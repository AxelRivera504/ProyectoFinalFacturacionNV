using Facturacion.Domain.Entities.Autorizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Infrastructure.Configs.Autorizacion
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        private string Table = "Usuarios";
        private string Schema = "Aut";
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Usuarios_Nombre",
                    "LEN([Nombre]) >= 2"
                );

                table.HasCheckConstraint(
                    "CK_Usuarios_UserName",
                    "LEN([UserName]) >= 4"
                );

                table.HasCheckConstraint(
                    "CK_Usuarios_Email",
                    "[Email] LIKE '%@%.%'"
                );
            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(150);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            builder.HasIndex(u => u.Email).IsUnique().HasDatabaseName("UQ_Usuarios_Email");
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(500);
        }
    }
}
