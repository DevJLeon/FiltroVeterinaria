using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TipoMovimiento:BaseEntity
{
    public string Descripcion {get;set;}
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos{get;set;}
}