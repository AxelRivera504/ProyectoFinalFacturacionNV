using Facturacion.Domain.Entities.Autorizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Infrastructure.Configs.Autorizacion
{
    internal class RolConfig : IEntityTypeConfiguration<Rol>
    {
        private const string Table = "Roles";
        private const string Schema = "Aut";

        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Roles_Nombre",
                    "LEN([Nombre]) >= 2"
                );

            });


            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(r => r.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(r => r.Nombre)
                .IsUnique()
                .HasDatabaseName("UQ_Roles_Nombre");

        }

    }
}
