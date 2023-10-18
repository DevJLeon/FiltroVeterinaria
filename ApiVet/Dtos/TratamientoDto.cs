using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
public class TratamientoDto
{
public int Id { get; set; }
public string Dosis {get;set;}
public string Observacion {get;set;}
public DateTime FechaAdministracion {get;set;}
public int CitaIdFk {get;set;}
public CitaDto Cita {get;set;}
public int MedicamentoIdFk {get;set;}
public MedicamentoDto Medicamento {get;set;}
}
}