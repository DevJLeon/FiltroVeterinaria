using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class MovimientoMedicamentoRepository  : GenericRepo<MovimientoMedicamento>, IMovimientoMedicamento
{
    protected readonly ApiContext _context;
    
    public MovimientoMedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientoMedicamentos
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientoMedicamentos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<object>> Consulta8B()
    {
        var Movimiento= await(
            from dM in _context.DetalleMovimientos
            join mM in _context.MovimientoMedicamentos on dM.MovimientoMedicamentoIdFk equals mM.Id
            select new
            {
                IdDetalleMovimiento = dM.Id,
                Medicamento=dM.Medicamento.Nombre,
                Movimiento=dM.Cantidad*dM.Precio
            }).Distinct()
            .ToListAsync();
        return Movimiento;
    }
}
}