using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("movimientoMedicamento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
    
            builder.Property(e => e.Cantidad)
            .HasColumnName("cantidad")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(e => e.Fecha)
            .HasColumnName("fecha")
            .HasColumnType("date")
            .IsRequired();

            builder.HasOne(p => p.TipoMovimiento)
            .WithMany(p => p.MovimientoMedicamentos)
            .HasForeignKey(p => p.TipoMovimientoIdFk); 
        }
    }