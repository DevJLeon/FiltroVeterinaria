using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMascota:IGenericRepo<Mascota>
    {
        Task<IEnumerable<object>> Consulta3A();
        Task<IEnumerable<object>> Consulta6A();
        Task<IEnumerable<object>> Consulta9B();
        Task<IEnumerable<object>> Consulta11B();
        Task<IEnumerable<object>> Consulta12B();
    }
}