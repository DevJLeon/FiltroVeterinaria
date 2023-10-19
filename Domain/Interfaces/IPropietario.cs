using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPropietario:IGenericRepo<Propietario>
    {
         Task<IEnumerable<object>> Consulta3A();
    }
}