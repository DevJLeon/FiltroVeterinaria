using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TratamientoMedico:BaseEntity
{
    public string Dosis {get;set;}
    public string Observacion {get;set;}
    public DateTime FechaAdministracion {get;set;}
    public int CitaIdFk {get;set;}
    public Cita Cita {get;set;}
    public int MedicamentoIdFk {get;set;}
    public Medicamento Medicamento {get;set;}
}