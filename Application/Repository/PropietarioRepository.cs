using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class PropietarioRepository  : GenericRepo<Propietario>, IPropietario
{
    protected readonly ApiContext _context;
    
    public PropietarioRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public async Task<IEnumerable<object>> Consulta2A()
    {
        var propietarios = 
            from p in _context.Propietarios
            select new
            {
                Nombre = p.Nombre,
                Mascotas = (
                    from m in _context.Mascotas
                    where m.PropietarioIdFk == p.Id
                    select new
                    {
                        Nombre = m.Nombre,
                        Especie = m.Raza.Especie.Nombre
                    }).ToList()
            };
            var Resultado = await propietarios.ToListAsync();
            return Resultado;
    }

} 
}