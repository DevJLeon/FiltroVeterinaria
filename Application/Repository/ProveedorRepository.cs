using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProveedorRepository  : GenericRepo<Proveedor>, IProveedor
{
    protected readonly ApiContext _context;
    
    public ProveedorRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<object>> Consulta10B()
    {
        var consulta = from m in _context.Medicamentos
        select new
        {
            Nombre = m.Nombre,
            proveedores = (from mp in _context.MedicamentoProveedores
                        join med in _context.Medicamentos on mp.MedicamentoIdFk equals med.Id
                        join p in _context.Proveedores on mp.ProveedorIdFk equals p.Id
                        where m.Id == mp.MedicamentoIdFk
                        select new
                        {
                            Nombre = p.Nombre
                        }).ToList()
        };

        var ProveedorMedicamento = await consulta.ToListAsync();
        return ProveedorMedicamento;
    }
}