using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class DetalleMovimiento:BaseEntity
{
    public int Cantidad {get;set;}
    public double Precio {get;set;}

    public int MedicamentoIdFk {get;set;}
    public Medicamento Medicamento {get;set;}
    public int MovimientoMedicamentoIdFk {get;set;}
    public MovimientoMedicamento MovimientoMedicamento {get;set;}
}