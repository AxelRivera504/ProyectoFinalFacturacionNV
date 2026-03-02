using Facturacion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Configs
{
    public static class EntidadBaseConfiguration
    {
        public static void Apply<TEntity>(EntityTypeBuilder<TEntity> builder, string tableName)
            where TEntity : EntidadBase
        {
            builder.HasKey(e => e.Id)
                .HasName($"PK_{tableName}");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.FechaModificacion)
                .IsRequired(false);

            builder.Property(e => e.EstaActivo)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(e => e.UsuarioCrea)
                .WithMany()
                .HasForeignKey(e => e.UsuarioCreacion)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"FK_{tableName}_UsuarioCrea");

            builder.HasOne(e => e.UsuarioModf)
                .WithMany()
                .HasForeignKey(e => e.UsuarioModificacion)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"FK_{tableName}_UsuarioModf");
        }
    }

}
