using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class TipoMovimientoRepository  : GenericRepo<TipoMovimiento>, ITipoMovimiento
{
    protected readonly ApiContext _context;
    
    public TipoMovimientoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.TipoMovimientos
            .ToListAsync();
    }

    public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.TipoMovimientos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 
}