using Application.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVeterinario:IGenericRepo<Veterinario>
    {
        Task<IEnumerable<Object>> Consulta1A();
    }
}