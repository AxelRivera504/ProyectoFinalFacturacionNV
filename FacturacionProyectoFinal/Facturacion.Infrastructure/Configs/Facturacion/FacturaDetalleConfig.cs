using Facturacion.Domain.Entities.Facturacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Infrastructure.Configs.Facturacion
{
    public class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        private const string Table = "FacturasDetalles";
        private const string Schema = "Fac";

        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_FacturasDetalles_Cantidad",
                    "[Cantidad] >= 0"
                );

                table.HasCheckConstraint(
                   "CK_FacturasDetalles_PrecioUnitario",
                    "[PrecioUnitario] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_FacturasDetalles_SubTotal",
                    "[SubTotal] >= 0"
                );
            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.HasOne(d => d.Factura)
                .WithMany(f => f.FacturaDetalles)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_FacturasDetalles_Facturas");

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_FacturasDetalles_Productos");

            builder.Property(d => d.Cantidad)
                .IsRequired();

            builder.Property(d => d.PrecioUnitario)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(d => d.SubTotal)
                .IsRequired()
                .HasPrecision(18, 2);
        }
    }

}
