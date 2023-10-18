using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario:BaseEntity
    {
        public string Nombre {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}

        public ICollection<UsuarioRol> UsuarioRoles {get;set;}
        public ICollection<RefreshToken> RefreshTokens {get;set;} = new HashSet<RefreshToken>();
        public ICollection<Rol> Roles {get;set;} = new HashSet<Rol>();
    }
}