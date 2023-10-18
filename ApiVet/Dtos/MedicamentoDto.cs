using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class MedicamentoDto
    {
        public int Id { get; set;}
        
            public string Nombre {get;set;}
    public int Cantidad {get;set;}
    public double Precio {get;set;}
    public int LaboratorioIdFk {get;set;}
    public LaboratorioDto Laboratorio {get;set;}
    }
}