using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mascota:BaseEntity
    {
        public string Nombre {get;set;}
        public DateOnly Nacimiento {get;set;}
        public int PropietarioIdFk {get;set;}
        public Propietario Propietario {get;set;}
        public int RazaIdFk { get; set; }
        public Raza Raza { get; set; }

        public ICollection<Cita> Citas{get;set;}
    }
}