using Facturacion.Domain.Entities.Facturacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Configs.Facturacion
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        private const string Table = "Productos";
        private const string Schema = "Fac";

        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Productos_Nombre",
                    "LEN([Nombre]) >= 2"
                );

                table.HasCheckConstraint(
                   "CK_Productos_Precio",
                    "[Precio] > 0"
                );

                table.HasCheckConstraint(
                    "CK_Productos_Stock",
                    "[Stock] >= 0"
                );

            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(p => p.Nombre)
                .IsUnique()
                .HasDatabaseName("UQ_Productos_Nombre");

            builder.Property(p => p.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.Precio)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.Stock)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.UnidadMedida)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
