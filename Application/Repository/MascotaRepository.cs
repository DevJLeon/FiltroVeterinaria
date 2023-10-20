using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
public class MascotaRepository  : GenericRepo<Mascota>, IMascota
{
    protected readonly ApiContext _context;
    
    public MascotaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<object>> Consulta3A()
    {
        var Especie =
        from e in _context.Especies
        select new
        {
            Especie = e.Nombre,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.RazaIdFk equals r.Id
                        where m.RazaIdFk == r.Id
                        where r.EspecieIdFk == e.Id
                        select new
                        {
                            Nombre = m.Nombre,
                            Raza = r.Nombre
                        }).ToList()
        };

        var MasEspecie = await Especie.ToListAsync();
        return MasEspecie;
    }
    public async Task<IEnumerable<object>> Consulta6A()
    {
        int año = 2023;
        DateTime trimestreInicio = new DateTime(año, 1, 1);
        DateTime trimestreFinal = new DateTime(año, 3, 31);

        var mascotas = await (
                        from c in _context.Citas
                        join m in _context.Mascotas on c.MascotaIdFk equals m.Id
                        where c.Motivo == "Vacunacion" && c.Fecha >= trimestreInicio && c.Fecha <= trimestreFinal
                        select new
                        {
                            Nombre=m.Nombre,
                            Motivo=c.Motivo,
                            Fecha=c.Fecha,
                            Veterinario=c.Veterinario.Nombre
                        }).Distinct()
                        .ToListAsync();
        return mascotas;
    }

    public async Task<IEnumerable<object>> Consulta9B()
    {
        var mascotas = 
        await (
            from c in _context.Citas
            join v in _context.Veterinarios on c.VeterinarioIdFk equals v.Id
            where c.VeterinarioIdFk == 1
            select new
            {
                Nombre=c.Mascota.Nombre,
                Propietario=c.Mascota.Propietario.Nombre,
                FechaCita=c.Fecha,
                Veterinario=v.Nombre
            }).Distinct()
            .ToListAsync();
        return mascotas;
    }
    public async Task<IEnumerable<object>> Consulta11B()
    {
        var mascotas = await (
            from m in _context.Mascotas
            join r in _context.Razas on m.RazaIdFk equals r.Id
            where m.Raza.Nombre == "Golden Retriever"
            select new
            {
                Nombre=m.Nombre,
                Propietario=m.Propietario.Nombre
            }).ToListAsync();
        return mascotas;
    }
    public async Task<IEnumerable<object>> Consulta12B()
    {
        var dato = from r in _context.Razas
                select new
                {
                    Nombre = r.Nombre,
                    Mascotas = _context.Mascotas.Distinct().Count(m => m.RazaIdFk == r.Id)
                };
        var Resultado = await dato.ToListAsync();
        return Resultado;
    }
} 
}