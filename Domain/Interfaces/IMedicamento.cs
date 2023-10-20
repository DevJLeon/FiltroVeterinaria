
using Application.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedicamento:IGenericRepo<Medicamento>
    {
        Task<IEnumerable<object>> Consulta2A();
        Task<IEnumerable<object>> Consulta5A();
    }
}