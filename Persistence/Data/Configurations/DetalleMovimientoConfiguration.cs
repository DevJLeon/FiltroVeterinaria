using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        // Aquí puedes configurar las propiedades de la entidad Marca
        // utilizando el objeto 'builder'.
        builder.ToTable("DetalleMovimiento");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id);

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int")
        .HasColumnName("cantidad")
        .HasMaxLength(5);

        builder.Property(p => p.Precio)
        .HasColumnName("precio")
        .HasColumnType("double")
        .IsRequired();
        
        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.MedicamentoIdFk);

        builder.HasOne(p => p.MovimientoMedicamento)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.MovimientoMedicamentoIdFk);
    }
}