using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class MascotaDto
    {  
        public string Id { get; set;}
                public string Nombre {get;set;}
        public DateOnly Nacimiento {get;set;}
        public int PropietarioIdFk {get;set;}
        public PropietarioDto Propietario {get;set;}
        public int RazaIdFk { get; set; }
        public RazaDto Raza { get; set; }

    }
}