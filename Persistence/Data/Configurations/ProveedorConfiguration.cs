using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("proveedor");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);


            builder.Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder
            .HasMany(p => p.Medicamentos)
            .WithMany(p => p.Proveedores)
            .UsingEntity<MedicamentoProveedor>(
                j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.MedicamentoIdFk),
                j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.ProveedorIdFk),
                j => 
                {
                    j.HasKey(t => new {t.ProveedorIdFk, t.MedicamentoIdFk});
                });
        }
    }