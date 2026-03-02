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
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        private const string Table = "Clientes";
        private const string Schema = "Fac";

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(Table, Schema, table =>
            {
                table.HasCheckConstraint(
                    "CK_Clientes_Nombre",
                    "LEN([Nombre]) >= 2"
                );

                table.HasCheckConstraint(
                   "CK_Clientes_Email",
                    "[Email] LIKE '%@%.%'"
                );

                table.HasCheckConstraint(
                    "CK_Clientes_Edad",
                    "[Edad] >= 0 AND [Edad] <= 150"
                );

                table.HasCheckConstraint(
                    "CK_Clientes_Identificacion",
                    "LEN([Identificacion]) >= 5"
                );

            });
            EntidadBaseConfiguration.Apply(builder, Table);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(c => c.Email)
                .IsUnique()
                .HasDatabaseName("UQ_Clientes_Email");

            builder.Property(c => c.Edad)
                .IsRequired();

            builder.Property(c => c.Identificacion)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(c => c.Identificacion)
                .IsUnique()
                .HasDatabaseName("UQ_Clientes_Identificacion");

            builder.Property(c => c.Telefono)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(c => c.Direccion)
                .IsRequired(false)
                .HasMaxLength(300);
        }
    }
}