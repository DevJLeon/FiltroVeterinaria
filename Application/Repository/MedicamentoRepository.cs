using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class MedicamentoRepository  : GenericRepo<Medicamento>, IMedicamento
{
    protected readonly ApiContext _context;
    
    public MedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
        .Include(p=>p.Laboratorio)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<object>> Consulta2A()
    {
        var medicamentos = await (
            from meds in _context.Medicamentos
            where meds.LaboratorioIdFk == 1
            select new
            {
                Nombre = meds.Nombre,
                Laboratorio=meds.Laboratorio.Nombre,
                Cantidad = meds.Cantidad
            }
        ).ToListAsync();
        return medicamentos;
    }
} 
}