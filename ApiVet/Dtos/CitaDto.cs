using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class CitaDto
    {
        public int Id { get; set;}
        public DateTime Fecha { get; set; }
        public string Motivo {get;set;}
        public int MascotaIdFk {get;set;}
        public MascotaDto Mascota {get;set;}
        public int VeterinarioIdFk {get;set;}
        public VeterinarioDto Veterinario  {get;set;}
    }
}