using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;
public class VeterinarioRepository  : GenericRepo<Veterinario>, IVeterinario
{
    protected readonly ApiContext _context;
    
    public VeterinarioRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios
            .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<Object>> Consulta1A(){
        var entidad = await(
            from v in _context.Veterinarios
            where v.Especialidad == "Cirujano Vascular"
            select new
            {
                Nombre = v.Nombre,
                Especialidad = v.Especialidad
            }).ToListAsync();
        return entidad;
    }
} 