using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class RazaDto
    {
        public int Id { get; set;}
        public string Nombre {get;set;}
        public int EspecieIdFk {get;set;}
        public EspecieDto Especie {get;set;}
        
    }
}