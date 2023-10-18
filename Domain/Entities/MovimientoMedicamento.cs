using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MovimientoMedicamento:BaseEntity
{
    public int Cantidad {get;set;}
    public DateOnly Fecha {get;set;}
    public int TipoMovimientoIdFk {get;set;}
    public TipoMovimiento TipoMovimiento {get;set;}

    public ICollection<DetalleMovimiento> DetalleMovimientos {get;set;}
}