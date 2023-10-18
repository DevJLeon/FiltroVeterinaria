using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("tratamientoMedico");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
        
        
            builder.Property(e => e.Dosis)
            .HasColumnName("dosis")
            .IsRequired();

            builder.Property(e => e.FechaAdministracion)
            .HasColumnName("fechaAdministracion")
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(e => e.Observacion)
            .HasColumnName("observacion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
        }
    }