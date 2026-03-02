using Facturacion.Domain.Entities.Autorizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Configs.Autorizacion
{
    public class PantallaConfig : IEntityTypeConfiguration<Pantalla>
    {
        private const string Table = "Pantallas";
        private const string Schema = "Aut";

        public void Configure(EntityTypeBuilder<Pantalla> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Pantallas_RutaPantalla",
                    "[RutaPantalla] LIKE '/%'"
                );

            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.Nombre)
                .IsUnique()
                .HasDatabaseName("UQ_Pantallas_Nombre");

            builder.Property(p => p.Icono)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.RutaPantalla)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(p => p.RutaPantalla)
                .IsUnique()
                .HasDatabaseName("UQ_Pantallas_RutaPantalla");
        }

    }
}
