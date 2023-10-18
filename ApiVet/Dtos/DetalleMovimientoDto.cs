using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class DetalleMovimientoDto
    {
    public int Id { get; set;}
    public int Cantidad {get;set;}
    public double Precio {get;set;}
    public int MedicamentoIdFk {get;set;}
    public MedicamentoDto Medicamento {get;set;}
    public int MovimientoMedicamentoIdFk {get;set;}
    public MovimientoMedicamentoDto MovimientoMedicamento {get;set;}
        
    }
}