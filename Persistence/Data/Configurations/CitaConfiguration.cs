using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Cita");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Fecha)
            .HasColumnName("fecha")
            .HasColumnType("date")
            .IsRequired();

            builder.Property(p => p.Motivo)
            .HasMaxLength(300)
            .HasColumnName("motivo")
            .IsRequired();

            builder.HasOne(p => p.Mascota)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.MascotaIdFk);

            builder.HasOne(p => p.Veterinario)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.VeterinarioIdFk);
        }
    }
}