using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("veterinario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Email)
            .HasColumnName("email")
            .IsRequired();

            builder.Property(e => e.Telefono)
            .HasColumnName("telefono")
            .IsRequired();

            builder.Property(e => e.Especialidad)
            .HasColumnName("especialidad")
            .HasMaxLength(250)
            .IsRequired();
        }
    }