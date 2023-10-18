using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    {
    }
    //public DbSet<>  { get; set; }
    public DbSet<Cita> Citas  { get; set; }
    public DbSet<DetalleMovimiento> DetalleMovimientos  { get; set; }
    public DbSet<Especie> Especies  { get; set; }
    public DbSet<Laboratorio> Laboratorios  { get; set; }
    public DbSet<Mascota> Mascotas  { get; set; }
    public DbSet<Medicamento> Medicamentos  { get; set; }
    public DbSet<MedicamentoProveedor> MedicamentoProveedores  { get; set; }
    public DbSet<MovimientoMedicamento> MovimientoMedicamentos {get;set;}
    public DbSet<Propietario> Propietarios  { get; set; }
    public DbSet<Proveedor> Proveedores  { get; set; }
    public DbSet<Raza> Razas  { get; set; }
    public DbSet<Rol> Roles {get;set;}
    public DbSet<TipoMovimiento> TipoMovimientos  { get; set; }
    public DbSet<TratamientoMedico> TratamientosMedicos  { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }
    public DbSet<Veterinario> Veterinarios  { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
