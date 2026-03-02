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
    public class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        private const string Table = "Facturas";
        private const string Schema = "Fac";

        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Facturas_Subtotal",
                    "[Subtotal] >= 0"
                );

                table.HasCheckConstraint(
                   "CK_Facturas_Impuesto",
                    "[Impuesto] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_Facturas_Total",
                    "[Total] >= 0"
                );
            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(f => f.FechaFactura)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Facturas_Clientes");

            builder.Property(f => f.Subtotal)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(f => f.Impuesto)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(f => f.Total)
                .IsRequired()
                .HasPrecision(18, 2);
        }
    }
}
